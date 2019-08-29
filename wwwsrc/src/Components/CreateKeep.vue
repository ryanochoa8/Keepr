<template>
  <div class="createKeep">
    <form @submit.prevent="addCreatedKeep">
      <div class="row justify-content-center m-1 pb-4 border border-secondary">
        <h5 class="col-12">Create a Keep</h5>
        <div class="row">
          <div class="col-6">
            <label for="name">Title: </label>
            <input type="text" name="name" placeholder="Enter a Title" v-model="newCreatedKeep.name">
          </div>
          <div class="col-6">
            <textarea for="description" cols="25" rows="1" v-model="newCreatedKeep.description"
              placeholder="Enter a Description"></textarea>
          </div>
          <div class="col-6">
            <label for="img">Image: </label>
            <input type="text" name="img" placeholder="Enter a URL" v-model="newCreatedKeep.img">
          </div>
          <div class="col-6">
            <label for="isPrivate">Do you want this private? </label>
            <input type="checkbox" name="isPrivate" v-model="newCreatedKeep.isPrivate">
          </div>
        </div>
        <button class="btn btn-primary btn-block mx-4" type="submit">Create Keep</button>
      </div>
    </form>

  </div>
</template>


<script>
  export default {
    name: 'createKeep',
    data() {
      return {
        newCreatedKeep: {
          name: "",
          description: "",
          img: "",
        }
      }
    },
    computed: {

    },
    methods: {
      addCreatedKeep(e) {
        this.$store.dispatch("addCreatedKeep", this.newCreatedKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>