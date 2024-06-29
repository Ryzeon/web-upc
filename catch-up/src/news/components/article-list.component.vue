<script setup>
import ArticleCard from "./article-card.component.vue";

export default {
  name: 'article-list',
  components: {ArticleCard},
  props: {
    articles: any
  }
}
</script>

<template>
  <div v-for="article in articles" :key="article.url">
    <article-card :article="article"/>
  </div>
</template>

<style scoped>

</style>