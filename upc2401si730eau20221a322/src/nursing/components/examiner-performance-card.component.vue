<script>
import {Examiner} from "../models/examiner.entity.js";
import {MentalExamApiService} from "../services/mental-exam-api.service.js";
import {MentalStateExam} from "../models/mental-state-exam.entity.js";

export default {
  name: "examiner-performance-card",
  props: {
    examiner: Examiner
  },
  data() {
    return {
      mentalExamApi: null,
      exams: [],
      averageExams: 0
    }
  },
  methods: {
    /**
     *
     * @param response as Json Array
     * @summary Builds a list of MentalStateExam objects from the response
     * @author Alex Avila Asto
     */
    buildExamListFromResponse(response) {
      return response.map(exam => {
        return new MentalStateExam(
            exam.id,
            exam.patientId,
            exam.examinerId,
            exam.examDate,
            exam.orientationScore,
            exam.registrationScore,
            exam.attentionAndCalculationScore,
            exam.recallScore,
            exam.languageScore
        )
      });
    },

    /**
     * @summary Using reduce to sum all the total scores of the exams and then divide by the number of exams to get the average score
     * @author Alex Avila Asto
     */
    calculateAverageExams() {
      // If there are no exams, the average is 0
      if (this.exams.length === 0) {
        this.averageExams = 0;
        return;
      }
      this.averageExams = this.exams.reduce((acc, exam) => {
        return acc + exam.calculateTotalScore();
      }, 0) / this.exams.length;
    }
  },
  created() {
    this.mentalExamApi = new MentalExamApiService();
    this.mentalExamApi.getByExaminerId(this.examiner.id).then((response) => {
      const data = response.data;
      this.exams = this.buildExamListFromResponse(data);
      this.calculateAverageExams();
    });
  },
}
</script>

<template>
  <pv-card class="shadow-4 text-center">
    <template #header>
      <p class="text-center font-bold ml-auto mt-1">
        {{$t('examiner-card.examiner')}}: {{examiner.firstName}} {{examiner.lastName}}
      </p>
    </template>
    <template #title>
      NPI: {{ examiner.nationalProviderIdentifier}}
    </template>
    <template #subtitle>
      {{$t('examiner-card.subtitle')}}
    </template>
    <template #content>
      <p>
        {{$t('examiner-card.count')}}: {{exams.length}}
      </p>

      <p>
        {{$t('examiner-card.average')}}: {{ averageExams.toFixed(2) }}
      </p>
    </template>
  </pv-card>
</template>

<style scoped>
</style>