<script>
import {ExaminerApiService} from "../services/examiner-api.service.js";
import {Examiner} from "../models/examiner.entity.js";
import ExaminerPerformanceCard from "../components/examiner-performance-card.component.vue";

export default {
  name: "examiner-performance-content",
  components: {ExaminerPerformanceCard},
  data() {
    return {
      examinerApi: null,
      examiners: []
    };
  },
  methods: {
    /**
     *
     * @param response as Json Array
     * @summary Builds a list of Examiner objects from the response
     * @author Alex Avila Asto
     */
    buildExaminerListFromResponse(response) {
      return response.map(examiner => {
        return new Examiner(
            examiner.id,
            examiner.firstName,
            examiner.lastName,
            examiner.nationalProviderIdentifier,
        )
      });
    }
  },
  created() {
    this.examinerApi = new ExaminerApiService();
    this.examinerApi.getAll().then((response) => {
      const data = response.data;
      this.examiners = this.buildExaminerListFromResponse(data);
    });
  }
}
</script>

<template>
  <div>
    <h1 class="text-center">
      {{ $t('examiner-performance-overview') }}
    </h1>
  </div>

  <div class="grid mr-5 ml-5">
    <div class="col-12 lg:col-6" v-for="examiner in examiners">
      <examiner-performance-card :examiner="examiner"/>
    </div>
  </div>
</template>

<style scoped>

</style>