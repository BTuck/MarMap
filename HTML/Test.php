<?php

/**
 * stock_ticker
 *
 * Generate an HTML stock ticker with current quotes.
 *
 * @version 2.5
 * @author Contributors at eXorithm
 * @link http://www.exorithm.com/algorithm/view/stock_ticker Listing at eXorithm
 * @link http://www.exorithm.com/algorithm/history/stock_ticker History at eXorithm
 * @license http://www.exorithm.com/home/show/license
 *
 * @param array $symbols stocks to go in the ticker
 * @param string $background_color (hex color code) color of the ticker background
 * @param string $stock_color (hex color code) color of the stock symbols
 * @param string $price_color (hex color code) color of the prices
 * @param string $up_color (hex color code) color of gains
 * @param string $down_color (hex color code) color of loses
 * @param number $speed speed of scrolling 
 * @return string HTML
 */
function stock_ticker($symbols=array(0=>'AAPL',1=>'GOOG',2=>'DOW',3=>'GCG13.CMX',4=>'P'),$background_color='dddddd',$stock_color='000000',$price_color='0000bb',$up_color='008000',$down_color='ff0000',$speed=6)
{
	sort($symbols);
	
	if ($background_color==$stock_color) {
		// something's wrong, colors weren't specified
		$background_color = invert_color($background_color);
	}
	
	$return = '<div align="center">
	<marquee bgcolor="#'.$background_color.'" loop="20" scrollamount="'.$speed.'">';
	
	foreach ($symbols as $symbol) {
		$data = file_get_contents("http://quote.yahoo.com/d/quotes.csv?s=$symbol&f=sl1d1t1c1ohgv&e=.csv");
		
		$values = explode(",", $data);
		$lasttrade = $values[1];
		$change = $values[4];
		
		$return .= "<span style=\"color:#$stock_color\">$symbol</span> &nbsp;";
		$return .= "<span style=\"color:#$price_color\">$lasttrade</span> &nbsp;";
		if ($change<0)
			$return .= "<span style=\"color:#$down_color\">$change</span> &nbsp;";
		else
			$return .= "<span style=\"color:#$up_color\">$change</span> &nbsp;";
		$return .= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
	}
	
	$return .= '</marque>
	</div>';
	
	return $return;
}

/**
 * invert_color
 *
 * Invert a color.
 *
 * @version 0.1
 * @author Contributors at eXorithm
 * @link http://www.exorithm.com/algorithm/view/invert_color Listing at eXorithm
 * @link http://www.exorithm.com/algorithm/history/invert_color History at eXorithm
 * @license http://www.exorithm.com/home/show/license
 *
 * @param string $color (hex color code) 
 * @return string hex color code
 */
function invert_color($color='008080')
{
	$new = '';
	for ($i=0;$i<3;$i++){
		$c = 255 - hexdec(substr($color,(2*$i),2));
		$c = dechex($c);
		$new .= (strlen($c) < 2) ? '0'.$c : $c;
	}
	return $new;
}

?>