<script>

import router from "../../router/index.js";

export default {
  name: "page-not-found.component",
  data() {
    return {
      invalidUrl: "",
    }
  },
  created() {
    this.invalidUrl = this.$route.fullPath
  },
  methods: {
    goHome() {
      console.log("goHome")
      router.push({ name: "home" })
    }
  }
}
</script>

<template>
  <div class="w-full f-full align-content-center flex-auto text-center bg-center ">
    <h1 class="flex-column align-items-center justify-content-center text-center text-red-500 text-6xl">
      Ooops! 404 Not Found
    </h1>
    <p class="flex-column align-items-center justify-content-center text-center text-red-500 text-3xl">
      The page {{ invalidUrl }} not exist.
    </p>
    <pv-button class="align-items-center justify-content-center" rounded
               @click="goHome"

    >
      Go Home
    </pv-button>
  </div>

</template>

<style scoped>

</style>