interface myProps {
    width?: number;
    height?: number;
    strokeWidth?: number;
}

export default ({ width = 24, height = 24, strokeWidth = 1 }: myProps) => {
    return (
        <svg
            version="1.1"
            id="Layer_1"
            xmlns="http://www.w3.org/2000/svg"
            x="0px" y="0px"
            viewBox="0 0 512 512"
            className="enable-background:new 0 0 512 512;"
            width={width}
            height={height}
            strokeWidth={strokeWidth}>
            <g>
                <g>
                    <g>
                        <path d="M256.01,106.667c29.461,0,53.333-23.872,53.333-53.333C309.343,23.893,285.471,0,256.01,0
				c-29.44,0-53.333,23.893-53.333,53.333C202.677,82.795,226.57,106.667,256.01,106.667z"/>
                        <path d="M351.776,303.701l-14.144-123.904c-3.349-29.525-26.752-51.819-54.4-51.819h-54.464c-27.648,0-51.051,22.272-54.4,51.819
				l-14.144,123.904c-1.173,10.368,2.027,20.651,8.768,28.224c5.803,6.528,13.547,10.304,21.909,10.773l11.776,159.403
				c0.427,5.568,5.056,9.899,10.645,9.899h85.333c5.589,0,10.219-4.309,10.645-9.877l11.776-159.403
				c8.384-0.469,16.107-4.267,21.909-10.773C349.77,324.373,352.949,314.069,351.776,303.701z"/>
                    </g>
                </g>
            </g>
        </svg>
    );
};