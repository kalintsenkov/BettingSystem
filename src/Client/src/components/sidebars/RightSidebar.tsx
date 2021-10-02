import Ad from "../ad/Ad";
import GamblerInfo from "../gamblerInfo/GamblerInfo";

const RightSidebar = (): JSX.Element => {
  return (
    <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6">
      <GamblerInfo />
      <Ad />
    </div>
  );
};

export default RightSidebar;
