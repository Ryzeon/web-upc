/**
 * Tutorials API Service Client
 * @description This class includes methods for typical REST resource operations.
 */
import http from "../../shared/services/http-common.js";

export class TutorialsApiService {
    getAll() {
        return http.get('/tutorials');
    }

    getById(id) {
        return http.get(`/tutorials/${id}`);
    }

    create(tutorialResource) {
        return http.post('/tutorials', tutorialResource);
    }

    update(id, tutorialResource) {
        return http.put(`/tutorials/${id}`, tutorialResource);
    }

    delete(id) {
        return http.delete(`/tutorials/${id}`);
    }

    findByTitle(title) {
        return http.get(`/tutorials?title=${title}`);
    }
}