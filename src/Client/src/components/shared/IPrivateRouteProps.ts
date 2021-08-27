import { RouteProps } from "react-router";

interface IPrivateRouteProps extends RouteProps {
    roles?: string[];
}

export default IPrivateRouteProps;