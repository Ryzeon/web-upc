import httpService from "../../shared/services/http-service.js";

export class ExamsApiService {

    getAll() {
        return httpService.get('/mental-state-exams');
    }
}