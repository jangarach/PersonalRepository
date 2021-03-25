<template>
  <div id="app">
    <Startsite/>
  </div>
</template>

<script>
import Startsite from './components/Startsite.vue'

export default {
  name: 'app',
  components:{
    Startsite
  },
  data () {
    return {
      msg: ' to Your Vue.js App'
    }
  }
}
</script>

<style>

</style>
