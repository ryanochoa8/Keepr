<template>
  <div class="Profile container-fluid justify-content-center">
    <div class="row justify-content-center">
      <router-link class="btn btn-primary my-2 col-2" to='/'>Home</router-link>
      <h1 class="row justify-content-center col-8">Dashboard</h1>
      <button v-if="user.id" @click="logout" class="btn btn-danger my-2 col-2">Logout</button>
    </div>
    <userKeeps></userKeeps>
    <userVaults></userVaults>
  </div>
</template>


<script>
  import userKeeps from '../Components/UserKeeps.vue'
  import userVaults from '../Components/UserVaults.vue'
  import router from '../router'


  export default {
    name: 'Profile',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getUserKeeps')
      this.$store.dispatch('getUserVaults')
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
      userKeeps,
      userVaults
    }
  }
</script>


<style scoped>

</style>