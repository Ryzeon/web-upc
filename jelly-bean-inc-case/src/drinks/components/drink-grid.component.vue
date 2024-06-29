<script>
import DrinkCard from "./drink-card.component.vue";


export default {
  name: "drink-grid",
  components: {DrinkCard},
  props: {drinks: Array},
}
</script>

<template>
  <div class="grid">
    <div class="col-6" v-for="drink in drinks" :key="drink.beanId" aria-label="drink-card">
      <drink-card class="mt-4" :drink="drink"/>
    </div>
  </div>
</template>

<style scoped>
</style>