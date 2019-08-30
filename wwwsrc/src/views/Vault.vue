<template>
  <div class="Vault container-fluid">
    <div class="row">
      <h3 class="col-12">{{activeVault.name}}</h3>
      <h6 class="col-12">{{activeVault.description}}</h6>
      <div v-for="keep in vault" class="col-4">
        <p>{{keep.name}}</p>
      </div>
    </div>
  </div>
</template>


<script>
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
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>