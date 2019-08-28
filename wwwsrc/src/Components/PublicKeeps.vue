<template>
  <div class="publicKeeps">
    <div class="col-4" v-for="keep in publicKeeps">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="keep.Img" alt="Card image cap">
        <h3 class="card-text">{{keep.Name}}</h3>
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