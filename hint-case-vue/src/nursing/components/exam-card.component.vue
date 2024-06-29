<script>
import {MentalStateExam} from "../models/mental-state-exam.entity.js";
import {PatientApiService} from "../services/patient-api.service.js";
import {ExaminerApiService} from "../services/examiner-api.service.js";
import {Patient} from "../models/patient.entity.js";
import {Examiner} from "../models/examiner.entity.js";

export default {
  name: "exam-card",
  props: {
    exam: MentalStateExam
  },
  data() {
    return {
      patientApi: null,
      examinerApi: null,
      patient: {},
      examiner: {},
      totalScore: 0
    }
  },
  created() {
    this.patientApi = new PatientApiService();
    this.examinerApi = new ExaminerApiService();

    this.patientApi.get(this.exam.patientId).then((response) => {
      const data = response.data;
      this.patient = new Patient(
          data.id,
          data.firstName,
          data.lastName,
          data.photoUrl,
          data.birthDate,
      );
      // console.log(this.patient);
    });

    this.examinerApi.get(this.exam.examinerId).then((response) => {
      const data = response.data;
      this.examiner = new Examiner(
          data.id,
          data.firstName,
          data.lastName,
          data.nationalProviderIdentifier
      );
      // console.log(this.examiner);
    });

    this.totalScore = this.exam.orientationScore + this.exam.registrationScore + this.exam.attentionAndCalculationScore + this.exam.recallScore + this.exam.languageScore;
  }
}
</script>

<template>
  <div>
    <pv-card class="bg-transparent border-0 shadow-0">
      <template #title>
        {{ $t('exam-id') }}# {{ exam.id }}
      </template>

      <template #content>
        <img :src="patient.photoUrl" alt="Patient photo" class="rounded-full w-5 h-5">
        <p>
          <span> {{ $t('patient-name') }}: </span>
          <span>{{ patient.firstName + " " + patient.lastName }}</span>
        </p>
        <p>
          <span> {{ $t('born-date') }}: </span>
          <span>{{ patient.birthDate }}</span>
        </p>
        <p>
          <span>{{ $t('exam-date') }}: </span>
          <span>{{ exam.examDate }}</span>
        </p>
        <p>
          <span>{{ $t('examiner-name') }}: </span>
          <span>{{ examiner.firstName + " " + examiner.lastName }}</span>
        </p>
        <p>
          <span>{{ $t('examiner-id') }}: </span>
          <span>{{ examiner.id }}</span>
        </p>
        <br>
        <p>
          <span>{{ $t('exam-score') }}: </span>
          <span>{{ totalScore }}</span>
        </p>
      </template>
    </pv-card>
  </div>
</template>

<style scoped>

</style>