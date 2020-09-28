import React, { Component } from 'react';
import { Map, TileLayer, Marker, Popup, Circle , Polygon } from 'react-leaflet';

export class MapNXT extends Component {
	render() {

        const state = { lat: 51.4417378, lng: 5.4750301, zoom: 13 }
        const position = [state.lat, state.lng]
        const circle = [51.461559, 5.477471]
        const polygon = [[51.441250, 5.474571], [51.442160, 5.474900], [51.441399, 5.475700]]

		return (
			<div className="map-container">
				<Map center={position} zoom={state.zoom}
					style={{ height: '800px' }}>
					<TileLayer
						tileSize={ 512 }
						zoomOffset={ -1 }
						attribution='&amp;copy <a href="https://www.maptiler.com/copyright/">Maptiler</a> contributors'
						url="https://api.maptiler.com/maps/streets/{z}/{x}/{y}.png?key=HfiQgsMsSnorjEs2Sxek"
					/>
					<Marker position={position}>
						<Popup>
							It's a secret to everybody
						</Popup>
					</Marker>

                    /*Red Circle for the Map*/
                    <Circle center={circle} 
                    color='red' 
                    fillColor='#f03' 
                    fillOpacity={0.5} 
                    radius={500} /> 
                        
                    /*Blue Triangle for the Location*/
                    <Polygon positions={polygon}/>

				</Map>
			</div>
        );
	}
}