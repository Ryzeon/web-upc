import httpService from "../../shared/services/http-service.js";

export class ExaminerApiService {
    get(id) {
        return httpService.get(`/examiners/${id}`);
    }
}