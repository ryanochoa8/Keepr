<template>
  <div class="home container-fluid">
    <div class="row m-2">
      <button v-if="user.id" @click="profile" class="btn btn-warning my-2 col-2">Profile</button>
      <h1 class="col-8">Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout" class="btn btn-danger my-2 col-2">Logout</button>
      <router-link v-else :to="{name: 'login'}" class="btn btn-primary my-2 col-2">Login</router-link>
    </div>
    <publicKeeps></publicKeeps>
  </div>
</template>

<script>
  import publicKeeps from '../Components/PublicKeeps.vue'
  import router from '../router'

  export default {
    name: "home",
    mounted() {
      this.$store.dispatch('getPublicKeeps')
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      profile() {
        router.push({ name: 'profile' })
      }
    },
    components: {
      publicKeeps
    }
  };
</script>