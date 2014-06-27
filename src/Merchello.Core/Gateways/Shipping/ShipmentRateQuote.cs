﻿namespace Merchello.Core.Gateways.Shipping
{
    using Models;

    /// <summary>
    /// Represents a shipment rate quote
    /// </summary>
    public class ShipmentRateQuote : IShipmentRateQuote
    {

        public ShipmentRateQuote(IShipment shipment, IShipMethod shipMethod)
            : this(shipment, shipMethod, new ExtendedDataCollection())
        {            
        }

        public ShipmentRateQuote(IShipment shipment, IShipMethod shipMethod, ExtendedDataCollection extendedData)
        {
            Mandate.ParameterNotNull(shipment, "shipment");
            Mandate.ParameterNotNull(shipMethod, "shipMethod");
            Mandate.ParameterNotNull(extendedData, "extendedData");

            shipment.ShipMethodKey = shipMethod.Key;

            Shipment = shipment;
            ShipMethod = shipMethod;
            ExtendedData = extendedData;
        }

        /// <summary>
        /// Gets the <see cref="IShipment"/> associated with this rate quote
        /// </summary>
        public IShipment Shipment { get; private set; }

        /// <summary>
        /// Gets the ShipMethod used to quote the rate
        /// </summary>
        public IShipMethod ShipMethod { get; private set; }

        /// <summary>
        /// Gets or sets the rate quoted by the ShipMethod
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets the extended data collection to store any additional information returned from
        /// a carrier based shipping.
        /// </summary>
        public ExtendedDataCollection ExtendedData { get; private set; }
    }
}