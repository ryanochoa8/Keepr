<template>
  <div class="userVaults row justify-content-center">
    <h3 class="row mx-2 border-bottom border-dark justify-content-center">Your Vaults</h3>
    <div class="row justify-content-center">
      <div class="col-3 m-4 px-1 justify-content-center card" v-for="userVault in userVaults" style="width: 18rem;">
        <div class="card-body">
          <h6 class="border-bottom pb-3">{{userVault.name}}</h6>
          <p>{{userVault.description}}</p>
          <div class="row justify-content-center">
            <button @click="deleteVaultById(userVault.id)" class="btn btn-danger col-3"><i
                class="far fa-trash-alt"></i></button>
            <button @click="viewVault(userVault)" class="offset-1 col-3"><i class="far fa-eye"></i></button>
          </div>
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
    methods: {
      deleteVaultById(id) {
        this.$store.dispatch("deleteVaultById", id)
      },
      viewVault(userVault) {
        this.$router.push({ name: "vault", params: { id: userVault.id } })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>