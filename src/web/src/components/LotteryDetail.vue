<template>
  <mdb-container>
    <mdb-row>
      <mdb-col md="4">
        <section class="form-elegant">
          <mdb-row>
            <mdb-col class="half-page column">
              <mdb-card>
                <mdb-card-body class="mx-4">
                  <div class="text-center">
                    <h3 class="dark-grey-text mb-5">
                      <strong>Sorteio</strong>
                    </h3>
                  </div>
                  <mdb-input label="Título" type="text" v-model="lottery.title" />
                  <mdb-input label="Descrição" type="textarea" v-model="lottery.description" />
                  <mdb-input label="Quando?" type="text" v-model="lottery.when" />
                  <mdb-input disabled="disabled" label="Criado em" type="text" v-model="lottery.createdAt" />
                  <div class="text-center mb-3">
                    <mdb-btn
                      type="button"
                      gradient="blue"
                      rounded
                      class="btn-block z-depth-1a"
                    >Salvar</mdb-btn>
                  </div>
                </mdb-card-body>
              </mdb-card>
            </mdb-col>
          </mdb-row>
        </section>
      </mdb-col>
      <mdb-col md="8">
        <h1>Participantes</h1>
        <mdb-tbl>
          <mdb-tbl-head>
            <tr>
              <th>Nome</th>
              <th>E-mail</th>
              <th>Números da sorte</th>
            </tr>
          </mdb-tbl-head>
          <mdb-tbl-body>
            <tr v-for="(item, idx) in lotteryParticipants" v-bind:key="idx">
              <th>{{item.name}}</th>
              <td>{{item.email}}</td>
              <td>{{item.luckNumbers}}</td>
            </tr>
          </mdb-tbl-body>
        </mdb-tbl>
      </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
import axios from "axios";
import {
  mdbRow,
  mdbCol,
  mdbCard,
  mdbCardBody,
  mdbInput,
  mdbBtn,
  mdbIcon,
  mdbModal,
  mdbModalBody,
  mdbModalFooter,
  mdbTbl,
  mdbTblHead,
  mdbTblBody,
  mdbJumbotron,
  mdbContainer
} from "mdbvue";
export default {
  name: "LotteryDetail",
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbCardBody,
    mdbInput,
    mdbBtn,
    mdbIcon,
    mdbModal,
    mdbModalBody,
    mdbModalFooter,
    mdbTbl,
    mdbTblHead,
    mdbTblBody,
    mdbJumbotron,
    mdbContainer
  },
  data: function() {
    return {
      lottery: {},
      lotteryParticipants:[]
    };
  },
  mounted: function(){
    console.log(this.$router);
    let lotteryId = this.$router.history.current.params.id;
    let self = this;
    axios
      .get(`https://localhost:5001/lottery/${lotteryId}`)
      .then(function (response) {
        self.lottery = response.data;
      })
      .catch(function (error) {
        console.log(error);
      });

    axios
      .get(`https://localhost:5001/lottery/${lotteryId}/participants`)
      .then(function (response) {
        console.log(response.data);
        self.lotteryParticipants = response.data;
      })
      .catch(function (error) {
        console.log(error);
      });
  }
};
</script>

<style>
.form-elegant .font-small {
  font-size: 0.8rem;
}

.form-elegant .z-depth-1a {
  -webkit-box-shadow: 0 2px 5px 0 rgba(55, 161, 255, 0.26),
    0 4px 12px 0 rgba(121, 155, 254, 0.25);
  box-shadow: 0 2px 5px 0 rgba(55, 161, 255, 0.26),
    0 4px 12px 0 rgba(121, 155, 254, 0.25);
}

.form-elegant .z-depth-1-half,
.form-elegant .btn:hover {
  -webkit-box-shadow: 0 5px 11px 0 rgba(85, 182, 255, 0.28),
    0 4px 15px 0 rgba(36, 133, 255, 0.15);
  box-shadow: 0 5px 11px 0 rgba(85, 182, 255, 0.28),
    0 4px 15px 0 rgba(36, 133, 255, 0.15);
}
</style>