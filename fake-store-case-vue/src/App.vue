<script setup>
import FooterContent from "./public/footer-content.component.vue";
import ToolbarContent from "./public/toolbar-content.component.vue";
import AnimalsGrid from "./animals/components/animals-grid.component.vue";
</script>

<template>
  <pv-toast/>
  <header aria-label="header-component">
    <toolbar-content/>
  </header>
  <div>
    <animals-grid/>
  </div>
  <footer-content/>
</template>
