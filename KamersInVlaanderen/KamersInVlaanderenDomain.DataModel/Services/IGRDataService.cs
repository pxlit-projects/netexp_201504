﻿using KamersInVlaanderen;
using System.Collections.Generic;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    public interface IGRDataService
    {
        List<GuestRoomJSON> getAllGuestRooms();
    }
}
