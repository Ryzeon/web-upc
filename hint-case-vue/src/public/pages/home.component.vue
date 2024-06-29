<script>
export default {
  name: "home.component"
}
</script>

<template>
  <div class="w-full">
    <img src="https://hign.org/sites/default/files/carousel-images/2022-02/iStock-945439872.jpg" alt="HIGN Hero Image" width="100%" height="100%">
  </div>

  <div class="hero-section-phrase">
    <p class="text-center text-3xl ">
      {{ $t('hero-section-phrase') }}
    </p>
  </div>

</template>

<style scoped>

</style>