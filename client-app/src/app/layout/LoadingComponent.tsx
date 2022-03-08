import { Dimmer, Loader } from "semantic-ui-react";

interface Props  {
    inverted?: boolean;
    content: string;
}

export default function LoadingComponent({inverted = true, content}: Props) {
    return (
        <Dimmer active={true} inverted={inverted}>
            <Loader contet={content}/>
        </Dimmer>
    );
}