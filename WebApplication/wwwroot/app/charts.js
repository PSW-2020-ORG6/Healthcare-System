Vue.component("charts", {
    data: function () {
        return {
            overallBackStat: "conic-gradient(Cornsilk 0,Cornsilk 38%,RosyBrown 38%,RosyBrown 61%,DarkGray 61%,DarkGray 100%)",
            overallBackStatFirst: "",
            overallBackStatSecond: "",

            overallBackStatThird: "",
            step21: "conic-gradient(Cornsilk 0,Cornsilk 38%,RosyBrown 38%,RosyBrown 61%,DarkGray 61%,DarkGray 100%)",
            step21percentsFWD: 38,
            step21percentsFSB: 23,
            step21percentsBCK: 39,

            step32: "conic-gradient(Cornsilk 0,Cornsilk 18%,RosyBrown 18%,RosyBrown 97%,DarkGray 97%,DarkGray 100%)",
            step32percentsFWD: 18,
            step32percentsFSB: 79,
            step32percentsBCK: 3,

            step43: "conic-gradient(Cornsilk 0,Cornsilk 32%,RosyBrown 32%,RosyBrown 65%,DarkGray 65%,DarkGray 100%)",
            step43percentsFWD: 32,
            step43percentsFSB: 33,
            step43percentsBCK: 35,

            appointments: "conic-gradient(Cornsilk 0,Cornsilk 38%,DarkGray 0,DarkGray 100%)",


            eventStatisticDTO: {}
        }
    },
    beforeMount() {
        axios
            .get('/event/eventStatistic', {
                headers: {
                    'Authorization': 'Bearer' + " " + localStorage.getItem('token')
                }
            })
            .then(response => {
                this.eventStatisticDTO = response.data
                this.step21percentsFWD = this.eventStatisticDTO.percentTransitionsToFirstStepZero
                this.step21percentsFSB = this.eventStatisticDTO.percentTransitionsToFirstStepOnce
                this.step21percentsBCK = this.eventStatisticDTO.percentTransitionsToFirstStepMore
                this.step21 = "conic-gradient(Cornsilk 0,Cornsilk " + String(this.step21percentsFWD) + "%,RosyBrown " + String(this.step21percentsFWD) + "%,RosyBrown " + String(this.step21percentsFSB + this.step21percentsFWD) + "%,DarkGray " + String(this.step21percentsFSB + this.step21percentsFWD) + "%,DarkGray " + String(this.step21percentsBCK + this.step21percentsFSB + this.step21percentsFWD) + "%)"


                this.step32percentsFWD = this.eventStatisticDTO.percentTransitionsToSecondStepZero
                this.step32percentsFSB = this.eventStatisticDTO.percentTransitionsToSecondStepOnce
                this.step32percentsBCK = this.eventStatisticDTO.percentTransitionsToSecondStepMore
                this.step32 = "conic-gradient(Cornsilk 0,Cornsilk " + String(this.step32percentsFWD) + "%,RosyBrown " + String(this.step32percentsFWD) + "%,RosyBrown " + String(this.step32percentsFSB + this.step32percentsFWD) + "%,DarkGray " + String(this.step32percentsFSB + this.step32percentsFWD) + "%,DarkGray " + String(this.step32percentsBCK + this.step32percentsFSB + this.step32percentsFWD) + "%)"

                this.step43percentsFWD = this.eventStatisticDTO.percentTransitionsToThirdStepZero
                this.step43percentsFSB = this.eventStatisticDTO.percentTransitionsToThirdStepOnce
                this.step43percentsBCK = this.eventStatisticDTO.percentTransitionsToThirdStepMore
                this.step43 = "conic-gradient(Cornsilk 0,Cornsilk " + String(this.step43percentsFWD) + "%,RosyBrown " + String(this.step43percentsFWD) + "%,RosyBrown " + String(this.step43percentsFSB + this.step43percentsFWD) + "%,DarkGray " + String(this.step43percentsFSB + this.step43percentsFWD) + "%,DarkGray " + String(this.step43percentsBCK + this.step43percentsFSB + this.step43percentsFWD) + "%)"

                this.appointmentsPercentsSUCC = this.eventStatisticDTO.percentIsAppointmentScheduled
                this.appointmentsPercentsQ = this.eventStatisticDTO.percentIsNotAppointmentScheduled
                this.appointments = "conic-gradient(Cornsilk 0,Cornsilk " + String(this.appointmentsPercentsSUCC) + "%,DarkGray " + String(this.appointmentsPercentsSUCC) + "%,DarkGray " + String(this.appointmentsPercentsQ + this.appointmentsPercentsSUCC) + "%)",

                    this.overallBackStatFirst = this.eventStatisticDTO.percenttTransitionsToFirstStep
                this.overallBackStatSecond = this.eventStatisticDTO.percenttTransitionsToSecondStep
                this.overallBackStatThird = this.eventStatisticDTO.percenttTransitionsToThirdStep
                this.overallBackStat = "conic-gradient(Cornsilk 0,Cornsilk " + String(this.overallBackStatFirst) + "%,RosyBrown " + String(this.overallBackStatFirst) + "%,RosyBrown " + String(this.overallBackStatSecond + this.overallBackStatFirst) + "%,DarkGray " + String(this.overallBackStatSecond + this.overallBackStatFirst) + "%,DarkGray " + String(this.overallBackStatThird + this.overallBackStatSecond + this.overallBackStatFirst) + "%)"


                this.specializationBack = this.eventStatisticDTO.percenttTransitionsToFirstStep
                this.doctorBack = this.eventStatisticDTO.percenttTransitionsToSecondStep
                this.dateTimeBack = this.eventStatisticDTO.percenttTransitionsToThirdStep

                this.averageTime = this.eventStatisticDTO.SchedulingDuration
            })
            .catch(error => {
            })




    },
    template: `
	<div id = "charts">

    <!--KORACI-->
    <br><br>
    <div class="container">
          <h2 class="head" >GOING BACK BY STEPS</h2>
          <br>
          <div class="row">
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepZero}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepOnce}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head " id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepMore}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Date selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepZero}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepOnce}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepMore}} %</h3>
                </div>   
                <div class="piechart" v-bind:style='{ backgroundImage: step32}'></div>
            <div id="text1">Specialization selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepZero}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepOnce}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepMore}} %</h3>
                </div>    
                <div class="piechart" v-bind:style='{ backgroundImage: step43}'></div>
                 <div id="text1">Doctor selection</div>
            </div>
          </div>

        <br><br>

        <h2 class="head">OVERALL</h2>
        <br>
        <div class="row">
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">DATE</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToFirstStep}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="bck head">SPECIALIZATION</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToSecondStep}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="quit head">DOCTOR</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToThirdStep}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: overallBackStat}'></div>
                <div id="text1">Return percentage per step  </div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">SUCCESSFUL</h3><h3 class="fwdPAP head" id = "blackText">{{this.eventStatisticDTO.percentIsAppointmentScheduled}} %</h3>
                </div>
                <hr>
                <div class="sameLine">
                    <h3 class="quit head">GAVE UP</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentIsNotAppointmentScheduled}} %</h3>
                </div>  
                    <br><br>
                    <div class="piechart" v-bind:style='{ backgroundImage: appointments}'></div>
                    <div id="text1">Appointment reservation performance</div>
             </div>
             <div class="col-sm">
                     <br><br><br><br><br><br><br><br>
                    <h2 class="head">AVERAGE TIME SPENT CREATING APPOINTMENT</h2>
                    <div class="sameLine">
                         <h3 id = "blackText" class="avgTime head">{{this.eventStatisticDTO.schedulingDuration}}</h3>
                    </div>
                 </div>
            </div>
       </div>
        <br><br>
       <br><br>
	</div>
	`,
});
