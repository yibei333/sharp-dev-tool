<script>
import { ServiceProvider } from '../services/serviceProvider'

export default {
  data() {
    return {
      service: null,
      platform: '',
      message: 'int',
      input: 'init',
      count: 1,
    }
  },
  async mounted() {
    let serviceProvider = new ServiceProvider();
    this.platform = await serviceProvider.getPlatform();
    this.service = await serviceProvider.getService();
    this.service.invokeAsync('GetMessage', this.input).then(x => {
      this.message = x;
    });
  },
  methods: {
    getMessage() {
      let data = {
        message: this.input,
        invokeJsMethod: (count) => {
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
    <h2>{{ platform }}</h2>
    <h2>{{ message }}</h2>
    <h2>{{ count }}</h2>
    <input v-model="input" />
    <button @click="getMessage">getMessage</button>
  </div>
</template>
