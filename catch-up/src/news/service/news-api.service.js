// News AIP Service
// axios import for making http requests
import axios from 'axios';
import {LogoApiService} from "../../shared/services/logo-api.service.js";

const http = axios.create({
    baseURL: 'https://newsapi.org/v2',
});

export class NewsApiService {
    // import from .env file NEWS_KEY
    apiKey = import.meta.env.NEWS_KEY;
    logoApi = new LogoApiService();

    getSources() {
        return http.get(`top-headlines/sources?apiKey=${this.apiKey}`);
    }

    getArticlesForSource(sourceId) {
        return http.get(`top-headlines?sources=${sourceId}&apiKey=${this.apiKey}`);
    }

    getUrlToLogo(src) {
        return this.logoApi.getUrlToLogo(src);
    }


}
