import {createRouter, createWebHistory} from "vue-router";
import HomeComponent from "../public/pages/home.component.vue";
import PageNotFoundComponent from "../public/pages/page-not-found.component.vue";
import ExaminerPerformanceContentComponent from "../nursing/pages/examiner-performance-content.component.vue";

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/home', name: 'home', component: HomeComponent,},
        {path: '/nursing/examiner-performance-overview', name: 'examiner-performance-overview', component: ExaminerPerformanceContentComponent},
        {path: '/', redirect: '/home'},
        {path: '/:pathMatch(.*)*', component: PageNotFoundComponent}
    ]
});

export default router;