<template>
  <div class="createVault">
    <form @submit.prevent="addCreatedVault">
      <div class="row justify-content-center m-1 pb-4 border border-secondary">
        <h5 class="col-12">Create a Vault</h5>
        <div class="row">
          <div class="col-6">
            <label for="name">Title: </label>
            <input type="text" name="name" placeholder="Enter a Title" v-model="newCreatedVault.name">
          </div>
          <div class="col-6">
            <textarea for="description" cols="25" rows="1" v-model="newCreatedVault.description"
              placeholder="Enter a Description"></textarea>
          </div>
        </div>
        <button class="btn btn-primary btn-block mx-4" type="submit">Create Vault</button>
      </div>
    </form>
  </div>
</template>


<script>
  export default {
    name: 'createVault',
    data() {
      return {
        newCreatedVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {},
    methods: {
      addCreatedVault(e) {
        this.$store.dispatch("addCreatedVault", this.newCreatedVault)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>