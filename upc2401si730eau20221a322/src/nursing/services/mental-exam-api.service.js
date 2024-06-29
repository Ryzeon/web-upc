import httpService from "../../shared/services/http-service.js";

export class MentalExamApiService {

    getAll() {
        return httpService.get('/mental-state-exams');
    }

    getByExaminerId(examinerId) {
        return httpService.get(`/mental-state-exams/?examinerId=${examinerId}`);
    }
}