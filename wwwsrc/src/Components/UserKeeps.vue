<template>
  <div class="userKeeps row justify-content-center">
    <h3 class="row mx-2 border-bottom border-dark justify-content-center">Your Keeps</h3>
    <div class="row justify-content-center">
      <div class="col-3 m-4 p-2 justify-content-center card d-flex" v-for="userKeep in userKeeps" style="width: 18rem;">
        <img class="card-img-top px-2" @click="viewKeep(userKeep)" :src="userKeep.img" alt="userKeep img">
        <div class="card-body">
          <h6 class="border-bottom pb-2">{{userKeep.name}}</h6>
          <p>{{userKeep.description}}</p>
          <div class="row justify-content-center">
            <p class="col-4"><i class="far fa-eye"></i><br>{{userKeep.views}}</p>
            <p class="col-4 border-right border-left border-secondary"><i
                class="far fa-share-square"></i><br>{{userKeep.shares}}</p>
            <p class="col-4"><i class="far fa-bookmark"></i><br>{{userKeep.keeps}}</p>
          </div>
          <div class="row justify-content-center">
            <button class="col-8 btn btn-outline-success">Share Keep <i class="far fa-share-square"></i></button>
            <!-- This should later be changed to a link or a modal -->
            <button @click="deleteKeepById(userKeep.id)" class="btn btn-outline-danger offset-1 col-3"><i
                class="far fa-trash-alt"></i></button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'userKeeps',
    data() {
      return {}
    },
    mounted() {
    },
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      }
    },
    methods: {
      deleteKeepById(id) {
        this.$store.dispatch("deleteKeepById", id)
      },
      viewKeep(userKeep) {
        this.$router.push({ name: "keep", params: { keepId: userKeep.id } })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>