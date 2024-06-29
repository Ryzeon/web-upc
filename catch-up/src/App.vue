<script>
import {NewsApiService} from "./news/service/news-api.service.js";
import {Article} from "./news/model/article.entity.js";
import SideMenu from "./news/components/side-menu-component.vue";
import ArticleList from "./news/components/article-list.component.vue";
import UnavailableContent from "./news/components/unavailable-content.component.vue";

export default {
  name: 'App',
  components: {UnavailableContent, ArticleList, SideMenu},
  data() {
    return {
      sidebarVisible: false,
      articles: [],
      errors: [],
      newsApi: new NewsApiService(),
    }
  },
  created() {
    // TODO: Get Articles for default source
    this.getArticlesFromSource("bbc-news")
  },
  methods: {
    buildArticleListFromResponseData(articles) {
      return articles.map(
          article => {
            return new Article(
                article.title,
                article.description,
                article.url,
                article.urlToImage,
                article.source
            );
          }
      );
    },
    getArticlesFromSource(sourceId) {
      this.newsApi.getArticlesFromSource(sourceId)
          .then(response => {
            this.articles = this.buildArticleListFromResponseData(response.data.articles);
            console.log(this.articles);
          })
          .catch(e => this.errors.push(e));
    },
    getArticlesForSourceWithLogo(source) {
      this.newsApi.getArticlesForSource(source.id)
          .then(response => {
            this.articles = this.buildArticleListFromResponseData(response.data.articles);
            this.articles.forEach(article => {
              article.source.urlToLogo = source.urlToLogo
            });
            console.log(this.articles);
          })
          .catch(e => this.errors.push(e));
    },

    toggleSidebar() {
      this.sidebarVisible = !this.sidebarVisible;
    },

    setSource(source) {
      this.getArticlesForSourceWithLogo(source);
      this.toggleSidebar();
    }
  },
}
</script>

<template>
  <div class="w-full">
    <div>
      <pv-menubar class="sticky bg-primary">
        <template #start>
          <pv-button icon="pi  pi-bard" label="CatchUp" text @click="toggleSidebar"/>
          <side-menu v-model:visible="sidebarVisible" v-on:source-selected="setSource"/>
        </template>
      </pv-menubar>
    </div>
  </div>
  <div>
    <article-list v-if="errors" :articles="articles"/>
    <unavailable-content v-else :errors="errors"/>
  </div>
</template>

<style scoped>
</style>
