<template>
  <div class="publicKeeps row justify-content-center">
    <div class="col-3 m-4 px-1 justify-content-center card" v-for="keep in publicKeeps" style="width: 18rem;">
      <img class="card-img-top" :src="keep.img" alt="keep img">
      <div class="card-body">
        <h6 class="border-bottom pb-3">{{keep.name}}</h6>
        <p>{{keep.description}}</p>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'publicKeeps',
    data() {
      return {}
    },
    mounted() {
      // this.$store.dispatch('getPublicKeeps')
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>