<template>
  <div class="Vault container-fluid">
    <div class="row">
      <button @click="profile" class="btn btn-warning my-2 offset-3 col-6">Return to Profile</button>
      <h3 class="col-12">{{activeVault.name}}</h3>
      <h6 class="col-12">{{activeVault.description}}</h6>
      <div v-for="keep in vault" class="col-4">
        <p>{{keep.name}}</p>
      </div>
    </div>
  </div>
</template>


<script>
  import router from '../router'


  export default {
    name: 'Vault',
    data() {
      return {}
    },
    mounted() {
      let data = {
        id: this.$route.params.id
      }
      this.$store.dispatch('getActiveVault', data)
      this.$store.dispatch('getKeepsByVaultId', data)
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      vault() {
        return this.$store.state.keepsByVault
      }
    },
    methods: {
      profile() {
        router.push({ name: 'profile' })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>