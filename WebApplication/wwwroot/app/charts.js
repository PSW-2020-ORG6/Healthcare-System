Vue.component("charts", {
    data: function () {
        return {

            step21: "conic-gradient(Cornsilk 0,Cornsilk 38%,RosyBrown 38%,RosyBrown 61%,DarkGray 61%,DarkGray 100%)",
            step32: "conic-gradient(Cornsilk 0,Cornsilk 18%,RosyBrown 18%,RosyBrown 97%,DarkGray 97%,DarkGray 100%)",
            step42: "conic-gradient(Cornsilk 0,Cornsilk 32%,RosyBrown 32%,RosyBrown 65%,DarkGray 65%,DarkGray 100%)",
            appointments: "conic-gradient(Cornsilk 0,Cornsilk 38%,DarkGray 0,DarkGray 100%)",
            step21percentsFWD: 38,
            step21percentsFSB: 23,
            step21percentsBCK: 39,
            step32percentsFWD: 18,
            step32percentsFSB: 79,
            step32percentsBCK: 3,
            step43percentsFWD: 32,
            step43percentsFSB: 33,
            step43percentsBCK: 35,
            appointmentsPercentsSUCC: 38,
            appointmentsPercentsQ: 62
        }
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
                    <h3 class="fwd head">FORWARD</h3><h3 class="fwdP head">{{step21percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">FORWARD WITH STEP BACK</h3><h3 class="bckP head">{{step21percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">QUIT</h3><h3 class="quitP head">{{step21percentsBCK}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Second step</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">FORWARD</h3><h3 class="fwdP head">{{step32percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">FORWARD WITH STEP BACK</h3><h3 class="bckP head">{{step32percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">QUIT</h3><h3 class="quitP head">{{step32percentsBCK}} %</h3>
                </div>               
                <div class="piechart" v-bind:style='{ backgroundImage: step32}'></div>
            <div id="text1">Third step</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">FORWARD</h3><h3 class="fwdP head">{{step43percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">FORWARD WITH STEP BACK</h3><h3 class="bckP head">{{step43percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">QUIT</h3><h3 class="quitP head">{{step43percentsBCK}} %</h3>
                </div>                 <div class="piechart" v-bind:style='{ backgroundImage: step42}'></div>
                 <div id="text1">Fourth step</div>
            </div>
          </div>

        <br><br>

        <h2 class="head">OVERALL SUCCESS</h2>
        <br>
        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">SUCCESSFUL</h3><h3 class="fwdPAP head">{{appointmentsPercentsSUCC}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">GAVE UP</h3><h3 class="quitP head">{{appointmentsPercentsQ}} %</h3>
                </div>
                    <div class="piechart" v-bind:style='{ backgroundImage: appointments}'></div>
                    <div id="text1">Appointment reservation performance</div>
             </div>
             <div class="col-sm">
             </div>
            </div>
       </div>

       <br><br>
	</div>
	`,
});