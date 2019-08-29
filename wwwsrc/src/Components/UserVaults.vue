<template>
  <div class="userVaults row justify-content-center">
    <h3 class="row mx-2 border-bottom border-dark justify-content-center">Your Vaults</h3>
    <div class="row justify-content-center">
      <div class="col-3 m-4 px-1 justify-content-center card" v-for="userVault in userVaults" style="width: 18rem;">
        <img class="card-img-top" :src="userVault.img" alt="userVault img">
        <div class="card-body">
          <h6 class="border-bottom pb-3">{{userVault.name}}</h6>
          <p>{{userVault.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'userVaults',
    data() {
      return {}
    },
    mounted() {
    },
    computed: {
      userVaults() {
        return this.$store.state.userVaults
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>