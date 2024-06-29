<script>
export default {
  name: "unavailable-content",
  props: {
    errors:  null
  }
}
</script>

<template>
<div>
  <div>
    <h4>
      Unavailable news.
    </h4>
  </div>
  <div v-for="error in error">
    <h6>
      {{ error}}
    </h6>
  </div>
</div>
</template>