exports.id=681,exports.ids=[681],exports.modules={6063:(e,t,r)=>{Promise.resolve().then(r.bind(r,6974)),Promise.resolve().then(r.t.bind(r,1900,23)),Promise.resolve().then(r.t.bind(r,1476,23)),Promise.resolve().then(r.bind(r,917)),Promise.resolve().then(r.bind(r,8482)),Promise.resolve().then(r.bind(r,1021))},9594:(e,t,r)=>{Promise.resolve().then(r.t.bind(r,2583,23)),Promise.resolve().then(r.t.bind(r,6840,23)),Promise.resolve().then(r.t.bind(r,8771,23)),Promise.resolve().then(r.t.bind(r,3225,23)),Promise.resolve().then(r.t.bind(r,9295,23)),Promise.resolve().then(r.t.bind(r,3982,23))},917:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>a});var s=r(5344),n=r(3729),i=r(6046),o=r.n(i);let a=()=>{let[e,t]=(0,n.useState)(!1);return(0,n.useEffect)(()=>{let e=setInterval(()=>{t(e=>!e)},1e3);return()=>clearInterval(e)},[]),(0,s.jsxs)("div",{className:o().lightcontainer,children:[s.jsx("div",{className:o().light}),s.jsx("div",{className:o().light,style:{left:"unset",right:0}})]})}},8482:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>m});var s=r(5344),n=r(3729),i=r(8529),o=r.n(i),a=r(6506);let l=({children:e,to:t})=>s.jsx(a.default,{href:t,children:s.jsx("div",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",children:e})});var c=r(4271),d=r.n(c);let _=()=>s.jsx("div",{children:(0,s.jsxs)("ul",{className:`flex ${d().list__button}`,children:[s.jsx("li",{className:`${d().container__button}`,children:s.jsx(l,{to:"/",children:"Inicio"})}),s.jsx("li",{children:s.jsx(l,{to:"/pages/proyects",children:"Proyectos"})})]})}),m=()=>{let[e,t]=(0,n.useState)(!1);return(0,s.jsxs)("div",{className:o().container,children:[s.jsx("div",{className:o().options_sreen,children:s.jsx(_,{})}),s.jsx("div",{className:o().menu_button,onClick:()=>{t(!e)},onMouseEnter:()=>{t(!0)},children:s.jsx("span",{})}),e?s.jsx("div",{className:o().modalContainer,onMouseLeave:()=>{t(!1)},children:s.jsx(_,{})}):null]})}},3456:(e,t,r)=>{"use strict";r.d(t,{Z:()=>a});var s=r(5344),n=r(8747),i=r.n(n),o=r(9410);let a=e=>{let{image:t,name:r,url:n,role:a}=e.proyect;return(0,s.jsxs)("div",{className:"m-4",children:[s.jsx(o.default,{className:`${i().image} max-w-48`,src:t,alt:r}),(0,s.jsxs)("div",{className:i().details,children:[s.jsx("h2",{className:"text-xl font-semibold mb-2",children:r}),(0,s.jsxs)("p",{className:"mb-2",children:["Url : ",n]}),(0,s.jsxs)("p",{className:"",children:["Role : ",a]})]})]})}},1021:(e,t,r)=>{"use strict";r.r(t),r.d(t,{ReduxProvider:()=>o});var s=r(5344),n=r(1531),i=r(6013);function o({children:e}){return s.jsx(i.zt,{store:n.h,children:e})}},7271:(e,t,r)=>{"use strict";r.d(t,{D:()=>i,Y:()=>o});var s=r(3608),n=r(9006);let i=async e=>{try{e((0,n.DS)());let t=await s.Z.get("https://proyectbox.onrender.com/api/Proyect");e((0,n.Qt)()),e((0,n.sT)({})),e((0,n.gK)(t.data))}catch(t){throw e((0,n.Qt)()),e((0,n.sT)(t)),Error("Error al tomar los Proyectos del Usuario"+t)}},o=async e=>{e((0,n.mc)())}},9006:(e,t,r)=>{"use strict";r.d(t,{DS:()=>i,Qt:()=>o,ZP:()=>c,gK:()=>n,mc:()=>l,sT:()=>a});let s=(0,r(7627).oM)({name:"Product",initialState:{allProduct:[],loading:!0,error:{message:""}},reducers:{reset:()=>({allProduct:[],loading:!0,error:{message:""}}),addProduct:(e,t)=>{e.allProduct=t.payload},setLoadingTrue:e=>{e.loading=!0,e.error={message:""}},setLoadingFalse:e=>{e.loading=!1},setError:(e,t)=>{e.loading=!1,e.error={message:t.payload.message}}}}),{addProduct:n,setLoadingTrue:i,setLoadingFalse:o,setError:a,reset:l}=s.actions,c=s.reducer},1531:(e,t,r)=>{"use strict";r.d(t,{C:()=>l,h:()=>a});var s=r(7627),n=r(9006),i=r(1455),o=r(6013);let a=(0,s.xC)({reducer:{productReducer:n.ZP},middleware:e=>e().concat(i.I)}),l=o.v9},4070:e=>{e.exports={container:"globals_container__6OqUP"}},6046:e=>{e.exports={lightcontainer:"LightAnimation_lightcontainer__gjYRJ",light:"LightAnimation_light__x98n1",lightAnimation:"LightAnimation_lightAnimation__42mVA"}},6672:e=>{e.exports={container:"Footer_container__Dj1D9",container__form:"Footer_container__form__LSKKV",container__imgLogo:"Footer_container__imgLogo__tHhCa"}},8529:e=>{e.exports={container:"DropMenu_container__aA_Zo",modalContainer:"DropMenu_modalContainer__ivj7Z",options_sreen:"DropMenu_options_sreen__vnyH6",menu_button:"DropMenu_menu_button__cYJmh",open:"DropMenu_open__UItSL"}},4075:e=>{e.exports={container:"NavBar_container__VY0s_",container__dropMenu:"NavBar_container__dropMenu__dMq0b",hide_mobile:"NavBar_hide_mobile__d1GFR"}},4271:e=>{e.exports={list__button:"NavOptions_list__button__p2JFa",container__button:"NavOptions_container__button__UddUs"}},8747:e=>{e.exports={image:"Item_image__uKOiq",details:"Item_details___3oBd"}},2338:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>L,metadata:()=>M});var s=r(5036);r(2);var n=r(4075),i=r.n(n),o=r(6843);let a=(0,o.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\NavBar\DropMenu\DropMenu.tsx`),{__esModule:l,$$typeof:c}=a,d=a.default,_={src:"/_next/static/media/OIG4.565f1274.webp"};var m=r(2813);let h=()=>(0,s.jsxs)("nav",{className:`${i().container} bg-gradient-to-b from-cards_bg to-transparent`,children:[s.jsx(m.default,{className:"h-16",src:_.src,alt:"Logo My Proyects"}),s.jsx("div",{className:i().container__dropMenu,children:s.jsx(d,{})})]});r(1659);var x=r(4070),u=r.n(x);let g=(0,o.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\redux\Provider.tsx`),{__esModule:p,$$typeof:v}=g;g.default;let j=(0,o.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\redux\Provider.tsx#ReduxProvider`),b=(0,o.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\Animations\LightAnimation.tsx`),{__esModule:f,$$typeof:A}=b,P=b.default;var y=r(6274),N=r(6672),w=r.n(N);let D=()=>(0,s.jsxs)("footer",{className:`${w().container} bg-gradient-to-b from-cards_bg to-transparent`,children:[s.jsx("div",{className:w().container__imgLogo,children:s.jsx(y.default,{href:"/",children:s.jsx(m.default,{src:_.src,alt:"Logo"})})}),s.jsx("div",{children:(0,s.jsxs)("fieldset",{className:w().container__form,children:[s.jsx("legend",{children:"Mis contactos"}),(0,s.jsxs)("ul",{children:[s.jsx("li",{children:"Email : nicoeloza12@gmail.com"}),s.jsx("li",{children:s.jsx(y.default,{href:"https://www.linkedin.com/in/nicoelozano/",target:"_blank",children:"Linkedin"})}),s.jsx("li",{children:s.jsx(y.default,{href:"https://github.com/nicolaselozano",target:"_blank",children:"Github"})})]})]})}),s.jsx("div",{children:s.jsx("button",{children:"Gracias por el espacio"})})]}),M={title:"Create Next App",description:"Generated by create next app"},L=({children:e})=>(0,s.jsxs)("html",{lang:"en",children:[(0,s.jsxs)("head",{children:[s.jsx("meta",{charSet:"utf-8"}),s.jsx("meta",{name:"viewport",content:"width=device-width, initial-scale=1.0"}),s.jsx("link",{rel:"stylesheet",href:"../output.css"}),s.jsx("link",{rel:"stylesheet",href:"https://fonts.googleapis.com/css2?family=Inter:wght@400;500;700&display=swap"}),s.jsx("title",{children:M.title}),s.jsx("meta",{name:"description",content:M.description})]}),(0,s.jsxs)("body",{className:"font-russo  text-white min-h-screen bg-gradient-to-b from-general_bg to-cards_bg ",children:[s.jsx(h,{}),(0,s.jsxs)("div",{className:u().container,children:[(0,s.jsxs)(j,{children:[e,s.jsx(P,{})]}),s.jsx(D,{})]})]})]})},6974:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>s});let s={src:"/_next/static/media/OIG4.565f1274.webp",height:1024,width:1024,blurDataURL:"data:image/webp;base64,UklGRpwAAABXRUJQVlA4WAoAAAAQAAAABwAABwAAQUxQSDcAAAABYBPbVqPrjIqKKphg0EDP5pyjgRWwCtEQEUlCdqcFTDs/0UMzDPcaILvff+lBb7L8HCDqS5EAAFZQOCA+AAAA0AEAnQEqCAAIAAJAOCWcNvj8HDeknWgA/vc0/8uf8hCjzv8qJ5j3y/5lWNITmNprgFqJu2wJpiwSWAA5gAA=",blurWidth:8,blurHeight:8}},3881:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>n});var s=r(337);let n=e=>[{type:"image/x-icon",sizes:"16x16",url:(0,s.fillMetadataSegment)(".",e.params,"favicon.ico")+""}]}};