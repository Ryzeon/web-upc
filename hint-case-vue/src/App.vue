<script setup>
import ToolbarContent from "./public/components/toolbar.component.vue";
</script>

<template>
  <pv-toast position="bottom-center"/>
  <header>
    <toolbar-content />
  </header>
  <div class="container">
    <router-view />
  </div>
</template>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  height: calc(100vh - 80px);
}
</style>