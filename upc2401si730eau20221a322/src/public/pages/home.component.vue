<script>
import MentalExamsAnalytics from "../../nursing/components/mental-exams-analytics.component.vue";

export default {
  name: "home.component",
  components: {MentalExamsAnalytics}
}
</script>

<template>
  <div>
    <h1 class="text-center">
      {{ $t('home') }}
    </h1>
    <p class="text-center text-3xl ">
      {{ $t('home-info') }}
    </p>
  </div>

  <mental-exams-analytics/>

</template>

<style scoped>

</style>