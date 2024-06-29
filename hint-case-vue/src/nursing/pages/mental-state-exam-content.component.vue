<script>
import {ExamsApiService} from "../services/exams-api.service.js";
import ExamCard from "../components/exam-card.component.vue";
import {MentalStateExam} from "../models/mental-state-exam.entity.js";

export default {
  name: "mental-state-exam-content.component",
  components: {ExamCard},
  data() {
    return {
      examsApi: null,
      exams: [],
    }
  },
  created() {
    this.examsApi = new ExamsApiService();

    this.examsApi.getAll().then((response) => {
      this.exams = this.createExamListFromResponse(response.data);
    });
  },
  methods: {
    createExamListFromResponse(data) {
      return data.map((exam) => {
        let mentalExam = new MentalStateExam();
        mentalExam.id = exam.id;
        mentalExam.patientId = exam.patientId;
        mentalExam.examinerId = exam.examinerId;
        mentalExam.examDate = exam.examDate;
        mentalExam.orientationScore = exam.orientationScore;
        mentalExam.registrationScore = exam.registrationScore;
        mentalExam.attentionAndCalculationScore = exam.attentionAndCalculationScore;
        mentalExam.recallScore = exam.recallScore;
        mentalExam.languageScore = exam.languageScore;
        return mentalExam;
      });

    }
  }
}
</script>

<template>
  <h1 class="text-center">
    {{ $t('mental-state-exams') }}
  </h1>
  <div class="grid mr-4 ml-4 text-center border-round-3xl shadow-8">
    <div v-for="exam in exams" class="col-12 md:col-6 lg:col-3">
      <exam-card :exam="exam"></exam-card>
    </div>
  </div>
</template>

<style scoped>

</style>