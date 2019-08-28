<template>
  <div class="home container-fluid">
    <div class="row">
      <h1>Welcome Home {{user.username}}</h1>
      <div class="row">
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
        <publicKeeps></publicKeeps>
      </div>
    </div>
  </div>
</template>

<script>
  import publicKeeps from '../Components/PublicKeeps.vue'

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
      }
    },
    components: {
      publicKeeps
    }
  };
</script>