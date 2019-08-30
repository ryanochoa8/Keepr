<template>
  <div class="Keep container-fluid">
    <div class="row">
      <h3 class="col-12">{{activeKeep.name}}</h3>
      <img class="col-8 offset-2" :src="activeKeep.img" alt="activeKeep img">
      <h6 class="col-12">{{activeKeep.description}}</h6>
      <div class="row">
        <div class="col-3 m-4 px-1 justify-content-center card" v-for="userVault in userVaults" style="width: 18rem;">
          <div class="card-body">
            <h6 class="border-bottom pb-3">{{userVault.name}}</h6>
            <p>{{userVault.description}}</p>
            <button class="col-12 btn btn-success" @click='addKeepToVault(userVault)'>Add Keep to Vault <i
                class="far fa-bookmark"></i></button>
          </div>
        </div>
      </div>
    </div>
  </div>
  </div>
</template>


<script>
  export default {
    name: 'Keep',
    data() {
      return {}
    },
    mounted() {
      let data = {
        id: this.$route.params.keepId
      }
      this.$store.dispatch('getActiveKeep', data)
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      userVaults() {
        return this.$store.state.userVaults
      }
    },
    methods: {
      addKeepToVault(userVault) {
        let data = {
          vaultId: userVault.id,
          keepId: this.$route.params.keepId
        }
        this.$store.dispatch('addKeepToVault', data)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>