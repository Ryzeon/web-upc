import {createRouter, createWebHistory} from "vue-router";
import HomeComponent from "../public/pages/home.component.vue";
import PageNotFoundComponent from "../public/pages/page-not-found.component.vue";
import MentalStateExamContentComponent from "../nursing/pages/mental-state-exam-content.component.vue";

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/home', name: 'home', component: HomeComponent,},
        {path: '/nursing/mental-state-exams', name: 'mental-state-exams', component: MentalStateExamContentComponent},
        {path: '/', redirect: '/home'},
        {path: '/:pathMatch(.*)*', component: PageNotFoundComponent}
    ]
});

export default router;