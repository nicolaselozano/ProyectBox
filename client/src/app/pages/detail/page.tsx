"use client"
import CDetail from "@/components/Details/Detail";
import { useSearchParams } from "next/navigation";

const Detail = () => {

    const searchParams = useSearchParams();
    const id = searchParams.get("id");
    
  return (
    <div>
      <CDetail id={`${id}`} />
    </div>
  );
};

export default Detail;

