import Link from "next/link";

interface Label {

    children:React.ReactNode,
    to:string
}

const Button_Nav:React.FC<Label> = ({children,to}:Label) => {

    return (

        <Link href={to}>
            <div className="bg-yellow-400 hover:bg-yellow-200 text-gray-950 font-bold py-2 px-4 rounded mt-2">
            {children}
            </div>
        </Link>
    )

}

export default Button_Nav;