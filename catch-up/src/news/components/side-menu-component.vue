<script>
import {NewsApiService} from "../service/news-api.service.js";

export default {
  name: "side-menu",
  props: {visible: Boolean},
  data() {
    return {
      sources: [],
      errors: [],
      newsApi: new NewsApiService()
    }
  },
  created() {
    this.newsApi.getSources()
        .then(response => {
          this.sources = response.data.sources;
          this.sources.forEach(src => {
            src.urlToLogo = this.newsApi.getUrlToLogo(src);
          });
        })
        .catch(error => {
          this.errors.push(error);
        });
  },
  methods: {
    onSourceSelected(source) {
      this.$emit('source-selected', source);
    },
    isVisible() {
      return this.visible;
    }
  }
}
</script>

<template>
  <pv-sidebar v:bind:visible="visible">
    <div v-for="source in sources" class="m-4">
      <div class="flex align-content-start flex-wrap" @click="onSourceSelected(source)">
        <span class="flex align-items-center justify-content-center mr-2">
          <pv-avatar :aria-label="source.name"
                     :image="source.urlToLogo"
                     shape="shape"/>
        </span>
        <span class="flex align-items-center justify-content-center mr-2">
              {{ source.name }}
        </span>
      </div>
    </div>
  </pv-sidebar>
</template>

<style scoped>

</style>