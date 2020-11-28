Vue.component("statistics", {
    data: function () {
        return {
            statisticEachQuestion: null,
            statisticEachTopic: null,
            selectedDoctor : "Doctor is not selected",
            statisticDoctor: null,
            doctorsList : null,
            widthLabel1Topic2: {
                width: '0%'
            },
            widthLabel2Topic2: {
                width: '0%'
            },
            widthLabel3Topic2: {
                width: '0%'
            },
            widthLabel3Topic2: {
                width: '0%'
            },
            widthLabel4Topic2: {
                width: '0%'
            },
            widthLabel5Topic2: {
                width: '0%'
            },

            widthLabel1Topic2Q6: {
                width: '0%'
            },
            widthLabel2Topic2Q6: {
                width: '0%'
            },
            widthLabel3Topic2Q6: {
                width: '0%'
            },
            widthLabel3Topic2Q6: {
                width: '0%'
            },
            widthLabel4Topic2Q6: {
                width: '0%'
            },
            widthLabel5Topic2Q6: {
                width: '0%'
            },


            widthLabel1Topic2Q7: {
                width: '0%'
            },
            widthLabel2Topic2Q7: {
                width: '0%'
            },
            widthLabel3Topic2Q7: {
                width: '0%'
            },
            widthLabel3Topic2Q7: {
                width: '0%'
            },
            widthLabel4Topic2Q7: {
                width: '60%'
            },
            widthLabel5Topic2Q7: {
                width: '0%'
            },

            widthLabel1Topic2Q8: {
                width: '0%'
            },
            widthLabel2Topic2Q8: {
                width: '0%'
            },
            widthLabel3Topic2Q8: {
                width: '0%'
            },
            widthLabel3Topic2Q8: {
                width: '0%'
            },
            widthLabel4Topic2Q8: {
                width: '0%'
            },
            widthLabel5Topic2Q8: {
                width: '0%'
            },


            widthLabel1Topic2Q9: {
                width: '0%'
            },
            widthLabel2Topic2Q9: {
                width: '0%'
            },
            widthLabel3Topic2Q9: {
                width: '0%'
            },
            widthLabel3Topic2Q9: {
                width: '0%'
            },
            widthLabel4Topic2Q9: {
                width: '0%'
            },
            widthLabel5Topic2Q9: {
                width: '0%'
            },

            widthLabel1Topic3Q10: {
                width: '0%'
            },
            widthLabel2Topic3Q10: {
                width: '0%'
            },
            widthLabel3Topic3Q10: {
                width: '0%'
            },
            widthLabel3Topic3Q10: {
                width: '0%'
            },
            widthLabel4Topic3Q10: {
                width: '0%'
            },
            widthLabel5Topic3Q10: {
                width: '0%'
            },

            widthLabel1Topic3Q11: {
                width: '0%'
            },
            widthLabel2Topic3Q11: {
                width: '0%'
            },
            widthLabel3Topic3Q11: {
                width: '0%'
            },
            widthLabel3Topic3Q11: {
                width: '0%'
            },
            widthLabel4Topic3Q11: {
                width: '0%'
            },
            widthLabel5Topic3Q11: {
                width: '0%'
            },

            widthLabel1Topic3Q12: {
                width: '0%'
            },
            widthLabel2Topic3Q12: {
                width: '0%'
            },
            widthLabel3Topic3Q12: {
                width: '0%'
            },
            widthLabel3Topic3Q12: {
                width: '0%'
            },
            widthLabel4Topic3Q12: {
                width: '0%'
            },
            widthLabel5Topic3Q12: {
                width: '0%'
            },

            widthLabel1Topic3Q13: {
                width: '0%'
            },
            widthLabel2Topic3Q13: {
                width: '0%'
            },
            widthLabel3Topic3Q13: {
                width: '0%'
            },
            widthLabel3Topic3Q13: {
                width: '0%'
            },
            widthLabel4Topic3Q13: {
                width: '0%'
            },
            widthLabel5Topic3Q13: {
                width: '0%'
            },


            widthLabel1Topic4Q14: {
                width: '0%'
            },
            widthLabel2Topic4Q14: {
                width: '0%'
            },
            widthLabel3Topic4Q14: {
                width: '0%'
            },
            widthLabel3Topic4Q14: {
                width: '0%'
            },
            widthLabel4Topic4Q14: {
                width: '0%'
            },
            widthLabel5Topic4Q14: {
                width: '0%'
            },

            widthLabel1Topic4Q15: {
                width: '0%'
            },
            widthLabel2Topic4Q15: {
                width: '0%'
            },
            widthLabel3Topic4Q15: {
                width: '0%'
            },
            widthLabel3Topic4Q15: {
                width: '0%'
            },
            widthLabel4Topic4Q15: {
                width: '0%'
            },
            widthLabel5Topic4Q15: {
                width: '0%'
            },

            widthLabel1Topic4Q16: {
                width: '0%'
            },
            widthLabel2Topic4Q16: {
                width: '0%'
            },
            widthLabel3Topic4Q16: {
                width: '0%'
            },
            widthLabel3Topic4Q16: {
                width: '0%'
            },
            widthLabel4Topic4Q16: {
                width: '0%'
            },
            widthLabel5Topic4Q16: {
                width: '0%'
            },

            widthLabel1Topic4Q17: {
                width: '0%'
            },
            widthLabel2Topic4Q17: {
                width: '0%'
            },
            widthLabel3Topic4Q17: {
                width: '0%'
            },
            widthLabel3Topic4Q17: {
                width: '0%'
            },
            widthLabel4Topic4Q17: {
                width: '0%'
            },
            widthLabel5Topic4Q17: {
                width: '0%'
            },

            widthLabel1Topic4Q18: {
                width: '0%'
            },
            widthLabel2Topic4Q18: {
                width: '0%'
            },
            widthLabel3Topic4Q18: {
                width: '0%'
            },
            widthLabel3Topic4Q18: {
                width: '0%'
            },
            widthLabel4Topic4Q18: {
                width: '0%'
            },
            widthLabel5Topic4Q18: {
                width: '0%'
            },

            widthLabel1Topic5Q19: {
                width: '60%'
            },
            widthLabel2Topic5Q19: {
                width: '60%'
            },
            widthLabel3Topic5Q19: {
                width: '60%'
            },
            widthLabel3Topic5Q19: {
                width: '60%'
            },
            widthLabel4Topic5Q19: {
                width: '60%'
            },
            widthLabel5Topic5Q19: {
                width: '60%'
            },

            widthLabel1Topic5Q20: {
                width: '60%'
            },
            widthLabel2Topic5Q20: {
                width: '60%'
            },
            widthLabel3Topic5Q20: {
                width: '60%'
            },
            widthLabel3Topic5Q20: {
                width: '60%'
            },
            widthLabel4Topic5Q20: {
                width: '60%'
            },
            widthLabel5Topic5Q20: {
                width: '60%'
            },


            widthLabel1Topic6Q21: {
                width: '60%'
            },
            widthLabel2Topic6Q21: {
                width: '60%'
            },
            widthLabel3Topic6Q21: {
                width: '60%'
            },
            widthLabel3Topi65Q21: {
                width: '60%'
            },
            widthLabel4Topic6Q21: {
                width: '60%'
            },
            widthLabel5Topic6Q21: {
                width: '60%'
            },

            widthLabel1Topic6Q22: {
                width: '60%'
            },
            widthLabel2Topic6Q22: {
                width: '60%'
            },
            widthLabel3Topic6Q22: {
                width: '60%'
            },
            widthLabel3Topi65Q22: {
                width: '60%'
            },
            widthLabel4Topic6Q22: {
                width: '60%'
            },
            widthLabel5Topic6Q22: {
                width: '60%'
            },

            widthLabel1Topic6Q23: {
                width: '60%'
            },
            widthLabel2Topic6Q23: {
                width: '60%'
            },
            widthLabel3Topic6Q23: {
                width: '60%'
            },
            widthLabel3Topi65Q23: {
                width: '60%'
            },
            widthLabel4Topic6Q23: {
                width: '60%'
            },
            widthLabel5Topic6Q23: {
                width: '60%'
            },


            widthLabel1Topic2SUM: {
                width: '60%'
            },
            widthLabel2Topic2SUM: {
                width: '60%'
            },
            widthLabel3Topic2SUM: {
                width: '60%'
            },
            widthLabel3Topi2SUM: {
                width: '60%'
            },
            widthLabel4Topic2SUM: {
                width: '60%'
            },
            widthLabel5Topic2SUM: {
                width: '60%'
            },


            widthLabel1Topic3SUM: {
                width: '60%'
            },
            widthLabel2Topic3SUM: {
                width: '60%'
            },
            widthLabel3Topic3SUM: {
                width: '60%'
            },
            widthLabel4Topic3SUM: {
                width: '60%'
            },
            widthLabel5Topic3SUM: {
                width: '60%'
            },

            widthLabel1Topic4SUM: {
                width: '60%'
            },
            widthLabel2Topic4SUM: {
                width: '60%'
            },
            widthLabel3Topic4SUM: {
                width: '60%'
            },
            widthLabel4Topic4SUM: {
                width: '60%'
            },
            widthLabel5Topic4SUM: {
                width: '60%'
            },

            widthLabel1Topic5SUM: {
                width: '60%'
            },
            widthLabel2Topic5SUM: {
                width: '60%'
            },
            widthLabel3Topic5SUM: {
                width: '60%'
            },
            widthLabel4Topic5SUM: {
                width: '60%'
            },
            widthLabel5Topic5SUM: {
                width: '60%'
            },

            widthLabel1Topic6SUM: {
                width: '60%'
            },
            widthLabel2Topic6SUM: {
                width: '60%'
            },
            widthLabel3Topic6SUM: {
                width: '60%'
            },
            widthLabel4Topic6SUM: {
                width: '60%'
            },
            widthLabel5Topic6SUM: {
                width: '60%'
            },

            widthLabel1Topic6SUM: {
                width: '60%'
            },
            widthLabel2Topic6SUM: {
                width: '60%'
            },
            widthLabel3Topic6SUM: {
                width: '60%'
            },
            widthLabel4Topic6SUM: {
                width: '60%'
            },
            widthLabel5Topic6SUM: {
                width: '60%'
            },


            widthLabel1DSUM: {
                width: '0%'
            },
            widthLabel2DSUM: {
                width: '0%'
            },
            widthLabel3DSUM: {
                width: '0%'
            },
            widthLabel4DSUM: {
                width: '0%'
            },
            widthLabel5DSUM: {
                width: '0%'
            },


            widthLabel1D1: {
                width: '0%'
            },
            widthLabel2D1: {
                width: '0%'
            },
            widthLabel3D1: {
                width: '0%'
            },
            widthLabel4D1: {
                width: '0%'
            },
            widthLabel5D1: {
                width: '0%'
            },


            widthLabel1D2: {
                width: '0%'
            },
            widthLabel2D2: {
                width: '0%'
            },
            widthLabel3D2: {
                width: '0%'
            },
            widthLabel4D2: {
                width: '0%'
            },
            widthLabel5D2: {
                width: '0%'
            },


            widthLabel1D3: {
                width: '0%'
            },
            widthLabel2D3: {
                width: '0%'
            },
            widthLabel3D3: {
                width: '0%'
            },
            widthLabel4D3: {
                width: '0%'
            },
            widthLabel5D3: {
                width: '0%'
            },


            widthLabel1D4: {
                width: '0%'
            },
            widthLabel2D4: {
                width: '0%'
            },
            widthLabel3D4: {
                width: '0%'
            },
            widthLabel4D4: {
                width: '0%'
            },
            widthLabel5D4: {
                width: '0%'
            }





        }
    },
    beforeMount() {



        axios
            .get('http://localhost:49900/feedback/approved')
            .then(response => {
                this.approvedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('http://localhost:49900/feedback/disapproved')
            .then(response => {
                this.disapprovedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('http://localhost:49900/patient/all')
            .then(response => {
                this.patients = response.data
            })
            .catch(error => {
                alert(error)
            })





        axios
            .get('http://localhost:49900/survey/getDoctors', { params: { patientId: "0003" } })
            .then(response => {
                this.doctorsList = response.data
            })
            .catch(error => {
                alert(error)
            })





    },
    mounted() {

        axios
            .get('http://localhost:49900/survey/getStatistiEachQuestion')
            .then(response => {
                this.statisticEachQuestion = response.data;

                this.widthLabel1Topic2.width = this.statisticEachQuestion[0].onesPercent;
                this.widthLabel2Topic2.width = this.statisticEachQuestion[0].twosPercent;
                this.widthLabel3Topic2.width = this.statisticEachQuestion[0].threesPercent;
                this.widthLabel4Topic2.width = this.statisticEachQuestion[0].foursPercent;
                this.widthLabel5Topic2.width = this.statisticEachQuestion[0].fivesPercent;

                this.widthLabel1Topic2Q6.width = this.statisticEachQuestion[1].onesPercent;
                this.widthLabel2Topic2Q6.width = this.statisticEachQuestion[1].twosPercent;
                this.widthLabel3Topic2Q6.width = this.statisticEachQuestion[1].threesPercent;
                this.widthLabel4Topic2Q6.width = this.statisticEachQuestion[1].foursPercent;
                this.widthLabel5Topic2Q6.width = this.statisticEachQuestion[1].fivesPercent;

                this.widthLabel1Topic2Q7.width = this.statisticEachQuestion[2].onesPercent;
                this.widthLabel2Topic2Q7.width = this.statisticEachQuestion[2].twosPercent;
                this.widthLabel3Topic2Q7.width = this.statisticEachQuestion[2].threesPercent;
                this.widthLabel4Topic2Q7.width = this.statisticEachQuestion[2].foursPercent;
                this.widthLabel5Topic2Q7.width = this.statisticEachQuestion[2].fivesPercent;

                this.widthLabel1Topic2Q8.width = this.statisticEachQuestion[3].onesPercent;
                this.widthLabel2Topic2Q8.width = this.statisticEachQuestion[3].twosPercent;
                this.widthLabel3Topic2Q8.width = this.statisticEachQuestion[3].threesPercent;
                this.widthLabel4Topic2Q8.width = this.statisticEachQuestion[3].foursPercent;
                this.widthLabel5Topic2Q8.width = this.statisticEachQuestion[3].fivesPercent;

                this.widthLabel1Topic2Q9.width = this.statisticEachQuestion[4].onesPercent;
                this.widthLabel2Topic2Q9.width = this.statisticEachQuestion[4].twosPercent;
                this.widthLabel3Topic2Q9.width = this.statisticEachQuestion[4].threesPercent;
                this.widthLabel4Topic2Q9.width = this.statisticEachQuestion[4].foursPercent;
                this.widthLabel5Topic2Q9.width = this.statisticEachQuestion[4].fivesPercent;



                this.widthLabel1Topic3Q10.width = this.statisticEachQuestion[5].onesPercent;
                this.widthLabel2Topic3Q10.width = this.statisticEachQuestion[5].twosPercent;
                this.widthLabel3Topic3Q10.width = this.statisticEachQuestion[5].threesPercent;
                this.widthLabel4Topic3Q10.width = this.statisticEachQuestion[5].foursPercent;
                this.widthLabel5Topic3Q10.width = this.statisticEachQuestion[5].fivesPercent;

                this.widthLabel1Topic3Q11.width = this.statisticEachQuestion[6].onesPercent;
                this.widthLabel2Topic3Q11.width = this.statisticEachQuestion[6].twosPercent;
                this.widthLabel3Topic3Q11.width = this.statisticEachQuestion[6].threesPercent;
                this.widthLabel4Topic3Q11.width = this.statisticEachQuestion[6].foursPercent;
                this.widthLabel5Topic3Q11.width = this.statisticEachQuestion[6].fivesPercent;

                this.widthLabel1Topic3Q12.width = this.statisticEachQuestion[7].onesPercent;
                this.widthLabel2Topic3Q12.width = this.statisticEachQuestion[7].twosPercent;
                this.widthLabel3Topic3Q12.width = this.statisticEachQuestion[7].threesPercent;
                this.widthLabel4Topic3Q12.width = this.statisticEachQuestion[7].foursPercent;
                this.widthLabel5Topic3Q12.width = this.statisticEachQuestion[7].fivesPercent;

                this.widthLabel1Topic3Q13.width = this.statisticEachQuestion[8].onesPercent;
                this.widthLabel2Topic3Q13.width = this.statisticEachQuestion[8].twosPercent;
                this.widthLabel3Topic3Q13.width = this.statisticEachQuestion[8].threesPercent;
                this.widthLabel4Topic3Q13.width = this.statisticEachQuestion[8].foursPercent;
                this.widthLabel5Topic3Q13.width = this.statisticEachQuestion[8].fivesPercent;



                this.widthLabel1Topic4Q14.width = this.statisticEachQuestion[9].onesPercent;
                this.widthLabel2Topic4Q14.width = this.statisticEachQuestion[9].twosPercent;
                this.widthLabel3Topic4Q14.width = this.statisticEachQuestion[9].threesPercent;
                this.widthLabel4Topic4Q14.width = this.statisticEachQuestion[9].foursPercent;
                this.widthLabel5Topic4Q14.width = this.statisticEachQuestion[9].fivesPercent;

                this.widthLabel1Topic4Q15.width = this.statisticEachQuestion[10].onesPercent;
                this.widthLabel2Topic4Q15.width = this.statisticEachQuestion[10].twosPercent;
                this.widthLabel3Topic4Q15.width = this.statisticEachQuestion[10].threesPercent;
                this.widthLabel4Topic4Q15.width = this.statisticEachQuestion[10].foursPercent;
                this.widthLabel5Topic4Q15.width = this.statisticEachQuestion[10].fivesPercent;

                this.widthLabel1Topic4Q16.width = this.statisticEachQuestion[11].onesPercent;
                this.widthLabel2Topic4Q16.width = this.statisticEachQuestion[11].twosPercent;
                this.widthLabel3Topic4Q16.width = this.statisticEachQuestion[11].threesPercent;
                this.widthLabel4Topic4Q16.width = this.statisticEachQuestion[11].foursPercent;
                this.widthLabel5Topic4Q16.width = this.statisticEachQuestion[11].fivesPercent;

                this.widthLabel1Topic4Q17.width = this.statisticEachQuestion[12].onesPercent;
                this.widthLabel2Topic4Q17.width = this.statisticEachQuestion[12].twosPercent;
                this.widthLabel3Topic4Q17.width = this.statisticEachQuestion[12].threesPercent;
                this.widthLabel4Topic4Q17.width = this.statisticEachQuestion[12].foursPercent;
                this.widthLabel5Topic4Q17.width = this.statisticEachQuestion[12].fivesPercent;

                this.widthLabel1Topic4Q18.width = this.statisticEachQuestion[13].onesPercent;
                this.widthLabel2Topic4Q18.width = this.statisticEachQuestion[13].twosPercent;
                this.widthLabel3Topic4Q18.width = this.statisticEachQuestion[13].threesPercent;
                this.widthLabel4Topic4Q18.width = this.statisticEachQuestion[13].foursPercent;
                this.widthLabel5Topic4Q18.width = this.statisticEachQuestion[13].fivesPercent;



                this.widthLabel1Topic5Q19.width = this.statisticEachQuestion[14].onesPercent;
                this.widthLabel2Topic5Q19.width = this.statisticEachQuestion[14].twosPercent;
                this.widthLabel3Topic5Q19.width = this.statisticEachQuestion[14].threesPercent;
                this.widthLabel4Topic5Q19.width = this.statisticEachQuestion[14].foursPercent;
                this.widthLabel5Topic5Q19.width = this.statisticEachQuestion[14].fivesPercent;

                this.widthLabel1Topic5Q20.width = this.statisticEachQuestion[15].onesPercent;
                this.widthLabel2Topic5Q20.width = this.statisticEachQuestion[15].twosPercent;
                this.widthLabel3Topic5Q20.width = this.statisticEachQuestion[15].threesPercent;
                this.widthLabel4Topic5Q20.width = this.statisticEachQuestion[15].foursPercent;
                this.widthLabel5Topic5Q20.width = this.statisticEachQuestion[15].fivesPercent;


                this.widthLabel1Topic6Q21.width = this.statisticEachQuestion[16].onesPercent;
                this.widthLabel2Topic6Q21.width = this.statisticEachQuestion[16].twosPercent;
                this.widthLabel3Topic6Q21.width = this.statisticEachQuestion[16].threesPercent;
                this.widthLabel4Topic6Q21.width = this.statisticEachQuestion[16].foursPercent;
                this.widthLabel5Topic6Q21.width = this.statisticEachQuestion[16].fivesPercent;

                this.widthLabel1Topic6Q22.width = this.statisticEachQuestion[17].onesPercent;
                this.widthLabel2Topic6Q22.width = this.statisticEachQuestion[17].twosPercent;
                this.widthLabel3Topic6Q22.width = this.statisticEachQuestion[17].threesPercent;
                this.widthLabel4Topic6Q22.width = this.statisticEachQuestion[17].foursPercent;
                this.widthLabel5Topic6Q22.width = this.statisticEachQuestion[17].fivesPercent;

                this.widthLabel1Topic6Q23.width = this.statisticEachQuestion[18].onesPercent;
                this.widthLabel2Topic6Q23.width = this.statisticEachQuestion[18].twosPercent;
                this.widthLabel3Topic6Q23.width = this.statisticEachQuestion[18].threesPercent;
                this.widthLabel4Topic6Q23.width = this.statisticEachQuestion[18].foursPercent;
                this.widthLabel5Topic6Q23.width = this.statisticEachQuestion[18].fivesPercent;
            })

        axios
            .get('http://localhost:49900/survey/getStatistiEachTopic')
            .then(response => {
                this.statisticEachTopic = response.data;

                this.widthLabel1Topic2SUM.width = this.statisticEachTopic[0].onesPercent;
                this.widthLabel2Topic2SUM.width = this.statisticEachTopic[0].twosPercent;
                this.widthLabel3Topic2SUM.width = this.statisticEachTopic[0].threesPercent;
                this.widthLabel4Topic2SUM.width = this.statisticEachTopic[0].foursPercent;
                this.widthLabel5Topic2SUM.width = this.statisticEachTopic[0].fivesPercent;

                this.widthLabel1Topic3SUM.width = this.statisticEachTopic[1].onesPercent;
                this.widthLabel2Topic3SUM.width = this.statisticEachTopic[1].twosPercent;
                this.widthLabel3Topic3SUM.width = this.statisticEachTopic[1].threesPercent;
                this.widthLabel4Topic3SUM.width = this.statisticEachTopic[1].foursPercent;
                this.widthLabel5Topic3SUM.width = this.statisticEachTopic[1].fivesPercent;

                this.widthLabel1Topic4SUM.width = this.statisticEachTopic[2].onesPercent;
                this.widthLabel2Topic4SUM.width = this.statisticEachTopic[2].twosPercent;
                this.widthLabel3Topic4SUM.width = this.statisticEachTopic[2].threesPercent;
                this.widthLabel4Topic4SUM.width = this.statisticEachTopic[2].foursPercent;
                this.widthLabel5Topic4SUM.width = this.statisticEachTopic[2].fivesPercent;

                this.widthLabel1Topic5SUM.width = this.statisticEachTopic[3].onesPercent;
                this.widthLabel2Topic5SUM.width = this.statisticEachTopic[3].twosPercent;
                this.widthLabel3Topic5SUM.width = this.statisticEachTopic[3].threesPercent;
                this.widthLabel4Topic5SUM.width = this.statisticEachTopic[3].foursPercent;
                this.widthLabel5Topic5SUM.width = this.statisticEachTopic[3].fivesPercent;

                this.widthLabel1Topic6SUM.width = this.statisticEachTopic[4].onesPercent;
                this.widthLabel2Topic6SUM.width = this.statisticEachTopic[4].twosPercent;
                this.widthLabel3Topic6SUM.width = this.statisticEachTopic[4].threesPercent;
                this.widthLabel4Topic6SUM.width = this.statisticEachTopic[4].foursPercent;
                this.widthLabel5Topic6SUM.width = this.statisticEachTopic[4].fivesPercent;
            })


    },
    beforeMount() {

        axios
            .get('http://localhost:49900/survey/getDoctors', { params: { patientId: "0003" } })
            .then(response => {
                this.doctorsList = response.data
            })
            .catch(error => {
                alert(error)
            })


    },
    template: `
    <div>











        <div id="sText">


<br></br>



            <select id = "selectDoctor" class="form-control custom-select" v-model = "selectedDoctor">
              <option div  v-for="(doctor) in doctorsList" v-bind:value="doctor" v-on:click="getStatisticsForDoctor()" >{{doctor}}</option>
            </select>



                               <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 v-if = "this.statisticDoctor != null" class="head-rate">{{this.statisticDoctor[4].averageRating}}</h2>
                                                                            <h2 v-else  class="head-rate">N/A</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>{{this.selectedDoctor}}</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5DSUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[4].fives}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4DSUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[4].fours}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3DSUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[4].threes}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2DSUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[4].twos}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1DSUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[4].ones}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>















 <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 v-if = "this.statisticDoctor != null" class="head-rate">{{this.statisticDoctor[0].averageRating}}</h2>
                                                                            <h2 v-else  class="head-rate">N/A</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 1</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5D1]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[0].fives}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4D1]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[0].fours}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3D1]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[0].threes}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2D1]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[0].twos}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1D1]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[0].ones}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 v-if = "this.statisticDoctor != null" class="head-rate">{{this.statisticDoctor[1].averageRating}}</h2>
                                                                            <h2 v-else  class="head-rate">N/A</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 2</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5D2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[1].fives}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4D2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[1].fours}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3D2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[1].threes}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2D2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[1].twos}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1D2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[1].ones}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                     <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 v-if = "this.statisticDoctor != null" class="head-rate">{{this.statisticDoctor[2].averageRating}}</h2>
                                                                            <h2 v-else  class="head-rate">N/A</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 3</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5D3]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[2].fives}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4D3]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[2].fours}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3D3]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[2].threes}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2D3]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[2].twos}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1D3]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[2].ones}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                      </div>






















<div class="row">
                                        <div class="col-sm">
                                                  
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 v-if = "this.statisticDoctor != null" class="head-rate">{{this.statisticDoctor[3].averageRating}}</h2>
                                                                            <h2 v-else  class="head-rate">N/A</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 4</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5D4]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[3].fives}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4D4]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[3].fours}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3D4]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[3].threes}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2D4]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[3].twos}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1D4]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td v-if = "this.statisticDoctor != null">{{this.statisticDoctor[3].ones}}</td>
                                                                                <td v-else >N/A</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                    
                                        </div>
                                      </div>















                        <br></br>
                        <br></br>
  
                        <!--TOPIC2-6-7-8 -->

<hr>

                                             <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachTopic[0].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>TOPIC 2 SUMMARY</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[0].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic2SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[0].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic2SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[0].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic2SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[0].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic2SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[0].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                       












                                      <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[0].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 5</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[0].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[0].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[0].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[0].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic2]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[0].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[1].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 6</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2Q6]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic2Q6]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic2Q6]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic2Q6]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic2Q6]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                     <div class="container-fluid px-1 py-5 mx-auto" >
                                                                               <div class="row justify-content-center">
                                                                                     <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                                            <div class="card">
                                                                                              <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                                                    <div class="rating-on-img">
                                                                                                        <h2 class="head-rate">{{this.statisticEachQuestion[2].averageRating}}</h2>
                                                                                                        <h3 class="subhead-rate">out of 5</h3>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="heading0 mb-3 text-center">
                                                                                                    <h2>QUESTION 7</h2>
                                                                                                </div>
                                                                                                <div class="rating-bar0 justify-content-center">
                                                                                                    <table class="text-left mx-auto">
                                                                                                        <tr>
                                                                                                            <td class="rating-label">5</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-5"  v-bind:style="[widthLabel5Topic2Q7]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[2].fives}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">4</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-4"  v-bind:style="[widthLabel4Topic2Q7]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[2].fours}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">3</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-3"  v-bind:style="[widthLabel3Topic2Q7]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[2].threes}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">2</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-2" v-bind:style="[widthLabel2Topic2Q7]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[2].twos}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">1</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-1" v-bind:style="[widthLabel1Topic2Q7]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[2].ones}}</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                                <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                                                <div class="review-head"> <a href="#">
                                                                                                      <br></br>
                                                                                                    </a> </div>
                                                                                   </div>
                                                                             </div>
                                                                       </div>
                                                             </div>
                                        </div>
                                      </div>

                        <!--8-9-->

                          <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[3].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 8</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2Q8]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[3].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic2Q8]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[3].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic2Q8]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[3].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic2Q8]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[3].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic2Q8]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[3].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[4].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 9</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2Q9]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[4].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic2Q9]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[4].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic2Q9]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[4].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic2Q9]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[4].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic2Q9]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[4].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                            
                                        </div>
                                      </div>
                        <br></br>
        

                        <!--TOPIC3-10-11-12-->

<hr>

               <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachTopic[1].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>TOPIC 3 SUMMARY</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic3SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[1].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic3SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[1].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic3SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[1].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic3SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[1].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic3SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[1].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>






                                      <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[5].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 10</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic3Q10]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[5].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic3Q10]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[5].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic3Q10]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[5].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic3Q10]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[5].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic3Q10]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[5].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[6].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 11</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic3Q11]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[6].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic3Q11]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[6].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic3Q11]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[1].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic3Q11]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[6].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic3Q11]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[6].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                     <div class="container-fluid px-1 py-5 mx-auto" >
                                                                               <div class="row justify-content-center">
                                                                                     <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                                            <div class="card">
                                                                                              <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                                                    <div class="rating-on-img">
                                                                                                        <h2 class="head-rate">{{this.statisticEachQuestion[7].averageRating}}</h2>
                                                                                                        <h3 class="subhead-rate">out of 5</h3>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="heading0 mb-3 text-center">
                                                                                                    <h2>QUESTION 12</h2>
                                                                                                </div>
                                                                                                <div class="rating-bar0 justify-content-center">
                                                                                                    <table class="text-left mx-auto">
                                                                                                        <tr>
                                                                                                            <td class="rating-label">5</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-5"  v-bind:style="[widthLabel5Topic3Q12]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].fives}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">4</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-4"  v-bind:style="[widthLabel4Topic3Q12]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].fours}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">3</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-3"  v-bind:style="[widthLabel3Topic3Q12]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].threes}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">2</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-2" v-bind:style="[widthLabel2Topic3Q12]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].twos}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">1</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-1" v-bind:style="[widthLabel1Topic3Q12]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].ones}}</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                                <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                                                <div class="review-head"> <a href="#">
                                                                                                      <br></br>
                                                                                                    </a> </div>
                                                                                   </div>
                                                                             </div>
                                                                       </div>
                                                             </div>
                                        </div>
                                      </div>

                        <!--13-->

                         <div class="row">
                                        <div class="col-sm">
                           
                                                    </div>
                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[8].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 13</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic3Q13]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[8].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic3Q13]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[8].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic3Q13]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[8].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic3Q13]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[8].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic3Q13]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[8].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                             
                                        </div>
                                      </div>
    


                        <br></br>
   

                        <!--TOPIC4-14-15-16-->


<hr>






<div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachTopic[2].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>TOPIC 4 SUMMARY</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic4SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[2].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic4SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[2].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic4SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[2].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic4SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[2].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic4SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[2].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>






                                      <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[9].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 14</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic4Q14]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[9].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic4Q14]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[9].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic4Q14]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[9].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic4Q14]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[9].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic4Q14]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[9].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[10].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 15</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic4Q15]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[10].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic4Q15]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[10].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic4Q15]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[10].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel4Topic4Q15]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[10].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic4Q15]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[10].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                     <div class="container-fluid px-1 py-5 mx-auto" >
                                                                               <div class="row justify-content-center">
                                                                                     <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                                            <div class="card">
                                                                                              <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                                                    <div class="rating-on-img">
                                                                                                        <h2 class="head-rate">{{this.statisticEachQuestion[11].averageRating}}</h2>
                                                                                                        <h3 class="subhead-rate">out of 5</h3>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="heading0 mb-3 text-center">
                                                                                                    <h2>QUESTION 16</h2>
                                                                                                </div>
                                                                                                <div class="rating-bar0 justify-content-center">
                                                                                                    <table class="text-left mx-auto">
                                                                                                        <tr>
                                                                                                            <td class="rating-label">5</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-5"  v-bind:style="[widthLabel5Topic4Q16]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[11].fives}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">4</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-4"  v-bind:style="[widthLabel4Topic4Q16]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[11].fours}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">3</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-3"  v-bind:style="[widthLabel3Topic4Q16]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[11].threes}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">2</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-2" v-bind:style="[widthLabel2Topic4Q16]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[11].twos}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">1</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-1" v-bind:style="[widthLabel1Topic4Q16]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[11].ones}}</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                                <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                                                <div class="review-head"> <a href="#">
                                                                                                      <br></br>
                                                                                                    </a> </div>
                                                                                   </div>
                                                                             </div>
                                                                       </div>
                                                             </div>
                                        </div>
                                      </div>


                        <!--17-18-->

                          <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[12].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 17</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic4Q17]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[12].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic4Q17]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[12].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic4Q17]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[12].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic4Q17]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[12].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic4Q17]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[12].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[13].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 18</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic4Q18]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[13].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic4Q18]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[13].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic4Q18]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[13].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic4Q18]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[13].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic4Q18]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[13].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                            
                                        </div>
                                      </div>

                        <br></br>


                        <!--TOPIC5-19-20-->

<hr>



<div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachTopic[3].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>TOPIC 5 SUMMARY</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic5SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic5SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic5SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic5SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic5SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>






                          <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[14].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 19</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic5Q19]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[14].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic5Q19]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[14].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic5Q19]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[14].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic5Q19]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[14].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic5Q19]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[14].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[15].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 20</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic2Q20]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[15].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic5Q20]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[15].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic5Q20]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[15].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic5Q20]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[15].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic5Q20]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[15].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                            
                                        </div>
                                      </div>

                        <br></br>
            

                        <!--TOPIC6-21-22-23-->



<hr>

<div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachTopic[4].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 6</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>TOPIC 6 SUMMARY</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic6SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[4].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic6SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[4].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic6SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[4].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic6SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[4].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic6SUM]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachTopic[3].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>








                                      <div class="row">
                                        <div class="col-sm">
                                                   <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[16].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 21</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic6Q21]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[16].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic6Q21]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[16].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic6Q21]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[16].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic6Q21]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[16].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic6Q21]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[16].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>

                                        <div class="col-sm">
                                           <div class="container-fluid px-1 py-5 mx-auto" >
                                                        <div class="row justify-content-center">
                                                            <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                <div class="card">
                                                                    <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                        <div class="rating-on-img">
                                                                            <h2 class="head-rate">{{this.statisticEachQuestion[17].averageRating}}</h2>
                                                                            <h3 class="subhead-rate">out of 5</h3>
                                                                        </div>
                                                                    </div>
                                                                    <div class="heading0 mb-3 text-center">
                                                                        <h2>QUESTION 22</h2>
                                                                    </div>
                                                                    <div class="rating-bar0 justify-content-center">
                                                                        <table class="text-left mx-auto">
                                                                            <tr>
                                                                                <td class="rating-label">5</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-5"  v-bind:style="[this.widthLabel5Topic6Q22]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[17].fives}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">4</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-4"  v-bind:style="[widthLabel4Topic6Q22]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[17].fours}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">3</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-3"  v-bind:style="[widthLabel3Topic6Q22]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[17].threes}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">2</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-2" v-bind:style="[widthLabel2Topic6Q22]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[17].twos}}</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rating-label">1</td>
                                                                                <td class="rating-bar">
                                                                                    <div class="bar-container">
                                                                                        <div class="bar-1" v-bind:style="[widthLabel1Topic6Q22]"></div>
                                                                                    </div>
                                                                                </td>
                                                                                <td>{{this.statisticEachQuestion[17].ones}}</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                    <div class="review-head"> <a href="#">
                                                                          <br></br>
                                                                        </a> </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </div>
                                        <div class="col-sm">
                                                     <div class="container-fluid px-1 py-5 mx-auto" >
                                                                               <div class="row justify-content-center">
                                                                                     <div class="col-xl-8 col-lg-9 col-md-10 col-12 text-center mb-5">
                                                                                            <div class="card">
                                                                                              <div class="cirle-img"> <img id="ratingImage" src="https://png.pngtree.com/thumb_back/fw800/background/20200821/pngtree-simple-light-blue-background-image_396574.jpg">
                                                                                                    <div class="rating-on-img">
                                                                                                        <h2 class="head-rate">{{this.statisticEachQuestion[18].averageRating}}</h2>
                                                                                                        <h3 class="subhead-rate">out of 5</h3>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="heading0 mb-3 text-center">
                                                                                                    <h2>QUESTION 23</h2>
                                                                                                </div>
                                                                                                <div class="rating-bar0 justify-content-center">
                                                                                                    <table class="text-left mx-auto">
                                                                                                        <tr>
                                                                                                            <td class="rating-label">5</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-5"  v-bind:style="[widthLabel5Topic6Q23]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[18].fives}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">4</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-4"  v-bind:style="[widthLabel4Topic6Q23]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[18].fours}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">3</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-3"  v-bind:style="[widthLabel3Topic6Q23]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[18].threes}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">2</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-2" v-bind:style="[widthLabel2Topic6Q23]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[18].twos}}</td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="rating-label">1</td>
                                                                                                            <td class="rating-bar">
                                                                                                                <div class="bar-container">
                                                                                                                    <div class="bar-1" v-bind:style="[widthLabel1Topic6Q23]"></div>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                            <td>{{this.statisticEachQuestion[7].ones}}</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                                <div> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> <span class="fa fa-star star-active"></span> </div>
                                                                                                <div class="review-head"> <a href="#">
                                                                                                      <br></br>
                                                                                                    </a> </div>
                                                                                   </div>
                                                                             </div>
                                                                       </div>
                                                             </div>
                                        </div>
                                      </div>
        




        </div>
    </div>



	`,




    methods: {
        getStatisticsForDoctor: function () {
            axios
                .get('http://localhost:49900/survey/getStatisticForDoctor', { params: { ID: this.selectedDoctor } })
                .then(response => {
                    this.statisticDoctor = response.data;


                    this.widthLabel1DSUM.width = this.statisticDoctor[4].onesPercent;
                    this.widthLabel2DSUM.width = this.statisticDoctor[4].twosPercent;
                    this.widthLabel3DSUM.width = this.statisticDoctor[4].threesPercent;
                    this.widthLabel4DSUM.width = this.statisticDoctor[4].foursPercent;
                    this.widthLabel5DSUM.width = this.statisticDoctor[4].fivesPercent;


                    this.widthLabel1D1.width = this.statisticDoctor[0].onesPercent;
                    this.widthLabel2D1.width = this.statisticDoctor[0].twosPercent;
                    this.widthLabel3D1.width = this.statisticDoctor[0].threesPercent;
                    this.widthLabel4D1.width = this.statisticDoctor[0].foursPercent;
                    this.widthLabel5D1.width = this.statisticDoctor[0].fivesPercent;


                    this.widthLabel1D2.width = this.statisticDoctor[1].onesPercent;
                    this.widthLabel2D2.width = this.statisticDoctor[1].twosPercent;
                    this.widthLabel3D2.width = this.statisticDoctor[1].threesPercent;
                    this.widthLabel4D2.width = this.statisticDoctor[1].foursPercent;
                    this.widthLabel5D2.width = this.statisticDoctor[1].fivesPercent;


                    this.widthLabel1D3.width = this.statisticDoctor[2].onesPercent;
                    this.widthLabel2D3.width = this.statisticDoctor[2].twosPercent;
                    this.widthLabel3D3.width = this.statisticDoctor[2].threesPercent;
                    this.widthLabel4D3.width = this.statisticDoctor[2].foursPercent;
                    this.widthLabel5D3.width = this.statisticDoctor[2].fivesPercent;


                    this.widthLabel1D4.width = this.statisticDoctor[3].onesPercent;
                    this.widthLabel2D4.width = this.statisticDoctor[3].twosPercent;
                    this.widthLabel3D4.width = this.statisticDoctor[3].threesPercent;
                    this.widthLabel4D4.width = this.statisticDoctor[3].foursPercent;
                    this.widthLabel5D4.width = this.statisticDoctor[3].fivesPercent;

                })
        }

    }


});