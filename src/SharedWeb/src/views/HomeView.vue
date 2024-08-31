<script>
import { SharpService } from '../services/sharp'

export default {
  data() {
    return {
      service: new SharpService(),
      message: 'init',
      input: 'init',
      count: 1,
    }
  },
  mounted() {
    this.service.invokeAsync('GetMessage', this.input).then(x => {
      this.message = x;
    });
  },
  methods: {
    getMessage() {
      let data = {
        message: this.input,
        test: (count) => {
          this.count = count;
        }
      };
      this.service.invokeWithReferenceAsync('GetOtherMessage', data).then(x => {
        this.message = x;
      });
    }
  }
}
</script>

<template>
  <div class="home">
    <h2>{{ message }}</h2>
    <h2>{{ count }}</h2>
    <input v-model="input" />
    <button @click="getMessage">test</button>
  </div>
</template>
