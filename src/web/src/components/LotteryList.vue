<template>
  <mdb-container>
    <h2 class="h1-responsive font-weight-bold text-center my-5">Sorteios</h2>
    <p class="text-center w-responsive mx-auto mb-5">
      Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
      cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
    </p>
    <mdb-btn
          color="success"
          size="md"
          class="waves-light"
          @click="createLottery()"
        >Novo sorteio</mdb-btn>
    <mdb-row v-for="(item, idx) in items" v-bind:key="idx" class="lottery-list-row">
      <mdb-col lg="5">
        <mdb-view class="rounded z-depth-2 mb-lg-0 mb-4" hover>
          <img class="img-fluid" v-bind:src="item.imageScr" v-bind:alt="item.imageAlt" />
          <router-link :to="{name: 'LotteryDetail', params: { id: item.id }}">
            <mdb-mask overlay="white-slight" waves />
          </router-link>
        </mdb-view>
      </mdb-col>
      <mdb-col lg="7">
        <h3 class="font-weight-bold mb-3 p-0">
          <strong>{{item.title}}</strong>
        </h3>
        <p>{{item.description}}</p>
        <p>
          by
          <a>
            <strong>{{item.createdBy}}</strong>
          </a>
          , {{item.createdAt}}
        </p>
        <mdb-btn
          color="success"
          size="md"
          class="waves-light"
          @click="seeMore(item.id)"
        >Ver mais</mdb-btn>
      </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
import {
  mdbContainer,
  mdbRow,
  mdbCol,
  mdbCard,
  mdbCardBody,
  mdbMask,
  mdbIcon,
  mdbView,
  mdbBtn
} from "mdbvue";
export default {
  name: "lotteryList",
  components: {
    mdbContainer,
    mdbRow,
    mdbCol,
    mdbCard,
    mdbCardBody,
    mdbMask,
    mdbIcon,
    mdbView,
    mdbBtn
  },
  props: ["items"],
  methods: {
    createLottery: function(){
      this.$router.push({ name: "NewLottery" });
    },
    seeMore: function(id) {
      this.$router.push({ name: "LotteryDetail", params: { id } });
    }
  }
};
</script>

<style scoped>
.lottery-list-row {
  padding: 2px;
}
</style>
