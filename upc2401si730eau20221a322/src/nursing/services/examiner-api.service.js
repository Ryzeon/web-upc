import httpService from "../../shared/services/http-service.js";

export class ExaminerApiService {
    getAll() {
        return httpService.get('/examiners');
    }
}