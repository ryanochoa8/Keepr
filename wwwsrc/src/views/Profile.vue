<template>
  <div class="Profile container-fluid">
    <div class="row m-2">
      <router-link class="btn btn-primary my-2 col-2" to='/'>Home</router-link>
      <h1 class="row justify-content-center col-8">Dashboard</h1>
      <button v-if="user.id" @click="logout" class="btn btn-danger my-2 col-2">Logout</button>
    </div>


  </div>
</template>


<script>
  export default {
    name: 'Profile',
    data() {
      return {}
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
    components: {}
  }
</script>


<style scoped>

</style>