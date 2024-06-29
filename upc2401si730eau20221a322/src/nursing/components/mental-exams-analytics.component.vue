<script>
import {MentalExamApiService} from "../services/mental-exam-api.service.js";
import {MentalStateExam} from "../models/mental-state-exam.entity.js";

export default {
  name: "mental-exams-analytics",
  data() {
    return {
      mentalExamApi: null,
      exams: [],
      highestScore: 0,
      lowestScore: 0,
      averageScore: 0
    };
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
     * @summary Gets all the exams from the API and sets the exams array with the response data
     * @author Alex Avila Asto
     */
    getExams() {
      this.mentalExamApi.getAll().then((response) => {
        const data = response.data;
        this.exams = this.buildExamListFromResponse(data);
        this.calculateScores();
      });
    },

    /**
     * @summary Calculates the highest, lowest, and average scores from the exams;
     * @author Alex Avila Asto
     */
    calculateScores() {
      // Explanation -> compare if a is greater than b, if it is set a as the new accumulator, if not, keep the accumulator as it is
      this.highestScore = this.exams.reduce((acc, exam) => {
        return exam.totalScore > acc ? exam.totalScore : acc;
      }, 0);
      // Explanation -> compare if a is less than b, if it is set a as the new accumulator, if not, keep the accumulator as it is
      this.lowestScore = this.exams.reduce((acc, exam) => {
        return exam.totalScore < acc ? exam.totalScore : acc;
      }, this.highestScore);
      // Explanation -> sum all the total scores and divide them by the number of exams
      this.averageScore = this.exams.reduce((acc, exam) => {
        return acc + exam.totalScore;
      }, 0) / this.exams.length;
    }
  },
  created() {
    this.mentalExamApi = new MentalExamApiService();
    this.getExams();
  }
}
</script>

<template>
  <div class="flex-auto flex-wrap w-auto text-center ml-auto mr-auto">
    <pv-card>
      <template #title>
        <p class="text-center text-2xl">
          {{ $t('card-analytics.title') }}
        </p>
      </template>

      <template #subtitle>
        <p class="text-center">
          {{ $t('card-analytics.subtitle') }}
        </p>

      </template>

      <template #content>
        <div class="flex flex-column align-content-center justify-content-center align-self-center">
          <div class="align-content-center justify-content-center align-self-center">
            <p class="text-center text-2xl">
              {{ $t('card-analytics.count') }}: {{ this.exams.length.toFixed(2) }}
            </p>
            <p class="text-center text-lg">

            </p>
          </div>

          <div class="align-content-center justify-content-center align-self-center">
            <p class="text-center text-2xl">
              {{ $t('card-analytics.highest') }}: {{ this.highestScore.toFixed(2) }}
            </p>
            <p class="text-center text-lg">

            </p>
          </div>

          <div class="align-content-center justify-content-center align-self-center">
            <p class="text-center text-2xl">
              {{ $t('card-analytics.lowest') }}: {{ this.lowestScore.toFixed(2) }}
            </p>
            <p class="text-center text-lg">

            </p>
          </div>

          <div class="align-content-center justify-content-center align-self-center">
            <p class="text-center text-2xl">
              {{ $t('card-analytics.average') }}: {{ this.averageScore.toFixed(2) }}
            </p>
          </div>
        </div>
      </template>
    </pv-card>
  </div>

</template>

<style scoped>

</style>