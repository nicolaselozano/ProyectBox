(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[783],{4817:function(e,t,r){Promise.resolve().then(r.bind(r,9043))},7907:function(e,t,r){"use strict";var n=r(5313);r.o(n,"usePathname")&&r.d(t,{usePathname:function(){return n.usePathname}}),r.o(n,"useSearchParams")&&r.d(t,{useSearchParams:function(){return n.useSearchParams}})},9043:function(e,t,r){"use strict";r.r(t),r.d(t,{default:function(){return C}});var n=r(3827),o=r(956),a=r(4090),c=r(828),i=r(5196),s=r(7908),l=r(8021),u=r(3724);let d=e=>async t=>{try{t((0,u.mc)()),t((0,u.K4)(!0));let r=await s.Z.get("".concat(l.QP,"/Proyect/").concat(e)),n=await f(e);console.log("aaaaaaaaaaa",n),t((0,u.Gr)({product:r.data,reviews:n})),t((0,u.K4)(!1))}catch(e){t((0,u.mc)()),t((0,u.K4)(!1)),t((0,u.sT)(e.response)),console.error("Error al obtner el detalle del Proyecto : "+e)}},m=e=>{e((0,u.mc)())},f=async e=>{try{return(await s.Z.get("".concat(l.QP,"/Review/count?PId=").concat(e))).data}catch(e){console.error(e)}};var g=r(8548),h=r.n(g),p=r(2063);let v=(e,t,r)=>async n=>{try{n((0,p.mc)()),n((0,p.K4)(!0));let o=localStorage.getItem("token"),a=await s.Z.post("".concat(l.QP,"/Review"),{like:r,emailUser:t,proyectId:e},{headers:{Authorization:"Bearer ".concat(o),"Content-Type":"application/json"}});console.log(a.data),n((0,p.K4)(!1))}catch(e){n((0,p.sT)(e)),console.error("Error response:",e)}},x=async(e,t)=>{try{let r=await s.Z.get("".concat(l.QP,"/Review?PId=").concat(e,"&userEmail=").concat(t));return console.log(r.data),r.data}catch(e){console.error(e.response)}};var y=e=>{let{id:t}=e,{product:r,reviews:s,loading:l}=(0,i.C)(e=>e.detailReducer),{error:u}=(0,i.C)(e=>e.reviewReducer),[f,g]=(0,a.useState)(s),p=(0,c.I0)(),[y,w]=(0,a.useState)(0);return(0,a.useEffect)(()=>(p(d(t)),()=>{p(m)}),[p,t]),(0,a.useEffect)(()=>{(null==u?void 0:u.status)===429&&alert("Se hicieron muchas request")},[u]),(0,a.useEffect)(()=>{(async()=>{let e=localStorage.getItem("email");if(e&&!l)try{await x(t,e)?(w(1),g(s)):w(0),g(s)}catch(e){console.error("Error fetching like count:",e),w(-1)}})()},[t,l]),(0,n.jsx)("div",{className:"flex justify-center",children:r&&Object.keys(r).length>0?(0,n.jsxs)("div",{children:[(0,n.jsxs)("div",{className:h().container__like,children:[(0,n.jsxs)("button",{type:"button",className:"text-violet-700 border border-violet-700 hover:bg-violet-700 hover:text-violet-200 focus:ring-2 focus:outline-none focus:ring-violet-300 font-medium rounded-full text-sm p-2.5 text-center inline-flex items-center dark:border-violet-500 dark:text-violet-500 dark:hover:text-violet-900 dark:focus:ring-violet-900 dark:hover:bg-violet-500",onClick:()=>{if(!localStorage.getItem("token"))return alert("Inicie sesi\xf3n para poder dar me gusta");let e=localStorage.getItem("email");1===y?(g(e=>e-1),w(0),p(v(t,e,!1))):0===y?(g(e=>e+1),w(1),p(v(t,e,!0))):g(s)},children:[(0,n.jsx)("svg",{className:"w-4 h-4","aria-hidden":"true",xmlns:"http://www.w3.org/2000/svg",fill:"currentColor",viewBox:"0 0 18 18",children:(0,n.jsx)("path",{d:"M3 7H1a1 1 0 0 0-1 1v8a2 2 0 0 0 4 0V8a1 1 0 0 0-1-1Zm12.954 0H12l1.558-4.5a1.778 1.778 0 0 0-3.331-1.06A24.859 24.859 0 0 1 6 6.8v9.586h.114C8.223 16.969 11.015 18 13.6 18c1.4 0 1.592-.526 1.88-1.317l2.354-7A2 2 0 0 0 15.954 7Z"})}),(0,n.jsx)("span",{className:"sr-only",children:"Icon description"})]}),(0,n.jsx)("span",{className:"ml-5",children:f||s})]}),(0,n.jsx)(o.Z,{proyect:r}),(0,n.jsx)("h1",{className:"ml-4",children:r.description})]}):(0,n.jsxs)("button",{disabled:!0,type:"button",className:"w-32 text-white bg-general_bg  focus:ring-4  font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 dark:bg-general_bg inline-flex items-center",children:[(0,n.jsxs)("svg",{"aria-hidden":"true",role:"status",className:"inline w-4 h-4 me-3 text-white animate-spin",viewBox:"0 0 100 101",fill:"none",xmlns:"http://www.w3.org/2000/svg",children:[(0,n.jsx)("path",{d:"M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z",fill:"#E5E7EB"}),(0,n.jsx)("path",{d:"M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z",fill:"currentColor"})]}),"Loading..."]})})},w=r(7907);let P=()=>{let e=(0,w.useSearchParams)().get("id");return(0,n.jsx)("div",{children:(0,n.jsx)(y,{id:"".concat(e)})})};function C(){return(0,n.jsx)(a.Suspense,{fallback:(0,n.jsx)("div",{children:"Loading..."}),children:(0,n.jsx)(P,{})})}},956:function(e,t,r){"use strict";var n=r(3827),o=r(3463),a=r.n(o);t.Z=e=>{let{proyect:t}=e,{image:r,name:o,url:c,role:i}=t;return(0,n.jsxs)("div",{className:"m-4",children:[(0,n.jsx)("img",{className:"".concat(a().image," max-w-48"),src:r,alt:o}),(0,n.jsxs)("div",{className:a().details,children:[(0,n.jsx)("h2",{className:"text-xl font-semibold mb-2",children:o}),(0,n.jsxs)("p",{className:"mb-2",children:["Url : ",c]}),(0,n.jsxs)("p",{className:"",children:["Role : ",i]})]})]})}},3724:function(e,t,r){"use strict";r.d(t,{Gr:function(){return o},K4:function(){return a},mc:function(){return c},sT:function(){return i}});let n=(0,r(1530).oM)({name:"detail",initialState:{product:{},reviews:null,loading:!1,error:{}},reducers:{reset:()=>({product:{},loading:!1,error:{},reviews:null}),setProduct:(e,t)=>{e.product=t.payload.product,e.reviews=t.payload.reviews,e.loading=!1},setLoading:(e,t)=>{e.loading=t.payload},setError:(e,t)=>{e.error=t.payload}}}),{setProduct:o,setLoading:a,reset:c,setError:i}=n.actions;t.ZP=n.reducer},8816:function(e,t,r){"use strict";r.d(t,{DS:function(){return a},Qt:function(){return c},gK:function(){return o},mc:function(){return s},sT:function(){return i}});let n=(0,r(1530).oM)({name:"Product",initialState:{MvotedProyect:{},allProduct:[],loading:!0,error:{}},reducers:{reset:()=>({MvotedProyect:{},allProduct:[],loading:!0,error:{}}),addProduct:(e,t)=>{e.allProduct=t.payload},setMvotedProyect:(e,t)=>{e.MvotedProyect=t.payload},setLoadingTrue:e=>{e.loading=!0,e.error={}},setLoadingFalse:e=>{e.loading=!1},setError:(e,t)=>{e.loading=!1,e.error=t.payload}}}),{addProduct:o,setLoadingTrue:a,setLoadingFalse:c,setError:i,reset:s}=n.actions;t.ZP=n.reducer},2063:function(e,t,r){"use strict";r.d(t,{K4:function(){return o},mc:function(){return c},sT:function(){return a}});let n=(0,r(1530).oM)({name:"reviews",initialState:{loading:!1,error:{}},reducers:{reset:()=>({loading:!1,error:{}}),setError:(e,t)=>{e.error=t.payload,e.loading=!1},setLoading:(e,t)=>{e.loading=t.payload}}}),{setLoading:o,setError:a,reset:c}=n.actions;t.ZP=n.reducer},5196:function(e,t,r){"use strict";r.d(t,{C:function(){return u},h:function(){return l}});var n=r(1530),o=r(8816),a=r(3724),c=r(2063),i=r(687),s=r(828);let l=(0,n.xC)({reducer:{productReducer:o.ZP,detailReducer:a.ZP,reviewReducer:c.ZP},middleware:e=>e().concat(i.I)}),u=s.v9},8021:function(e,t,r){"use strict";r.d(t,{Cx:function(){return c},He:function(){return s},IC:function(){return a},QP:function(){return l},u8:function(){return n},yK:function(){return o},yO:function(){return i}});let n="https://PORTAFOLIO_API.com",o="dev-v2roygalmy6qyix2.us.auth0.com",a="offline_access",c="FiGgFZqBNRTXMtroNlRxerrS9FEwWca8",i="code",s="https://proyectbox-au5d.onrender.com",l="https://proyectbox.onrender.com/api"},8548:function(e){e.exports={container__like:"Detail_container__like__pCdbL"}},3463:function(e){e.exports={image:"Item_image__uKOiq",details:"Item_details___3oBd"}}},function(e){e.O(0,[477,908,971,69,744],function(){return e(e.s=4817)}),_N_E=e.O()}]);