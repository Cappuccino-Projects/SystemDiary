import React, { useState } from 'react'
import "./scss/style.scss"
import { TimetableAddCallsHeader as TBHeader } from "@Widgets/TimetableAddCallsHeader"
import { Card, CardHead, CardBody, CardFooter } from '@Components/Card'
import { useEffect } from 'react'

export default function TimetableAddCalls() {


	return (
		<div className='timetable-add-calls'>
			<TBHeader indexPage={0} />

			<Card>
				<CardHead>
					Header
				</CardHead>
                <CardBody>
                    Body
                </CardBody>
                <CardFooter>
                    Footer
                </CardFooter>
			</Card>

		</div>
	);
}